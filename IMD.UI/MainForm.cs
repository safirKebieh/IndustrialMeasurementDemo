using System.ComponentModel;
using IMD.Core.Device;
using IMD.Core.Models;
using IMD.Core.Persistence;
using IMD.Infrastructure.Repositories;
using IMD.Core.Services;
using Microsoft.Extensions.Configuration;
using IMD.UI.Services;
using IMD.UI.Ui;

namespace IMD.UI
{
    public partial class MainForm : Form
    {
        private IDeviceClient? _device;
        private CancellationTokenSource? _cts;

        private readonly BindingList<MeasurementRow> _rows = new();

        private IMeasurementRepository? _repo;
        private string? _dbPath;

        private readonly IConfiguration _config;
        private readonly ToleranceSettings _toleranceSettings;
        private readonly ToleranceService _toleranceService;
        private readonly CalibrationSettings _calibrationSettings;

        private readonly int _connectTimeoutSeconds;
        private readonly int _maxGridRows;

        private readonly string _deviceHost;
        private readonly int _devicePort;

        private readonly string _dbFileName;

        private MeasurementDbWriter? _dbWriter;
        private MeasurementProcessor? _processor;

        private readonly QualityStats _stats = new();

        private UiLogger? _logger;
        private UiDispatcher? _ui;

        public MainForm()
        {
            InitializeComponent();

            _logger = new UiLogger(listLog);
            _ui = new UiDispatcher(this);

            // 1) Configuration (appsettings.json)
            _config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            _connectTimeoutSeconds =
                int.TryParse(_config["Connection:ConnectTimeoutSeconds"], out var timeoutSecondsFromConfig)
                    ? timeoutSecondsFromConfig
                    : 5;

            _maxGridRows =
                int.TryParse(_config["UI:MaxGridRows"], out var maxGridRowsFromConfig)
                    ? maxGridRowsFromConfig
                    : 50;

            _deviceHost = _config["Device:Host"] ?? "127.0.0.1";

            var portText = _config["Device:Port"] ?? "9000";
            _devicePort =
                int.TryParse(portText, out var devicePortFromConfig)
                    ? devicePortFromConfig
                    : 9000;

            _dbFileName = _config["Database:FileName"] ?? "measurements.db";

            // 2) Domain settings + services (bind from config, fallback to defaults)
            _toleranceSettings =
                _config.GetSection("Tolerance").Get<ToleranceSettings>()
                ?? new ToleranceSettings();

            _toleranceService = new ToleranceService(_toleranceSettings);

            _calibrationSettings =
                _config.GetSection("Calibration").Get<CalibrationSettings>()
                ?? new CalibrationSettings();

            // Create processor (logic extracted from UI loop)
            _processor = new MeasurementProcessor(_toleranceService, _calibrationSettings);

            // 3) UI init
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            lblCurrentTarget.Text =
                $"Target: {_toleranceSettings.TargetWidth:F1} ±{_toleranceSettings.WidthTolerance:F2} mm   |   " +
                $"{_toleranceSettings.TargetWeight:F1} ±{_toleranceSettings.WeightTolerance:F2} g";

            gridMeasurements.AutoGenerateColumns = true;
            gridMeasurements.DataSource = _rows;

            GridConfigurator.Configure(gridMeasurements, ex => _logger?.Log("Grid error: " + ex.Message));

            ThemeManager.ApplyMainTheme(root: tlpRoot, pnlCurrentCard: pnlCurrentCard, pnlStatsCard: pnlStatsCard,
                                        pnlSystem: pnlSystem,
                                        gridMeasurements: gridMeasurements,
                                        listLog: listLog,
                                        btnConnect: btnConnect,
                                        btnStart: btnStart,
                                        btnStop: btnStop,
                                        lblCurrentTitleFirst: lblCurrentTitleFirst,
                                        lblCurrentValueFirst: lblCurrentValueFirst,
                                        lblCurrentTarget: lblCurrentTarget);

            // 4) DB init (local app data + configurable file name)
            var appDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "IndustrialMeasurementDemo");

            Directory.CreateDirectory(appDir);

            _dbPath = Path.Combine(appDir, _dbFileName);

            _repo = new EfMeasurementRepository(_dbPath);
            _ = _repo.InitializeAsync(CancellationToken.None);

            // NEW: DB writer service
            _dbWriter = new MeasurementDbWriter(_repo);
            _dbWriter.StatusChanged += OnDbStatusChanged;
            _dbWriter.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ResetStats();

            UpdateConnectionStatus("Disconnected");

            lblRunValue.Text = "Run: Stopped";
            lblConnValue.Text = "Connection: Disconnected";
            lblLastSampleValue.Text = "Last sample: -";
            lblLastDbValue.Text = "DB: -";

            _logger?.Log($"DB: {_dbPath}");

            _logger?.Log($"Calibration: width(off={_calibrationSettings.WidthOffset}, gain={_calibrationSettings.WidthGain}) " +
                $"weight(off={_calibrationSettings.WeightOffset}, gain={_calibrationSettings.WeightGain})");
        }

        private void OnDbStatusChanged(string status)
        {
            _ui?.Invoke(() =>
            {
                if (status.StartsWith("DB: OK"))
                {
                    lblLastDbValue.Text = "DB: Connected to Sqlite Database";
                    lblLastDbValue.ForeColor = Color.LightGreen;
                }
                else
                {
                    lblLastDbValue.Text = "DB: ERROR";
                    lblLastDbValue.ForeColor = Color.OrangeRed;
                    _logger?.Log(status);
                }
            });
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;

                _device = new TcpDeviceClient();

                using var connectCts = new CancellationTokenSource(TimeSpan.FromSeconds(_connectTimeoutSeconds));

                await _device.ConnectAsync(_deviceHost, _devicePort, connectCts.Token);

                _logger?.Log($"Connected to {_deviceHost}:{_devicePort}");
                UpdateConnectionStatus($"Connected to {_deviceHost}:{_devicePort}");

                lblConnValue.Text = $"Connection: Connected to {_deviceHost}:{_devicePort}";
                lblSystemTitle.Text = $"System: {Environment.MachineName}";

                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger?.Log("Connect failed: " + ex.Message);
                UpdateConnectionStatus("Connect failed");

                lblConnValue.Text = "Connection: Connect failed";

                btnConnect.Enabled = true;
                await DisposeDeviceAsync();
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_device is null)
            {
                _logger?.Log("Not connected.");
                return;
            }

            if (_processor is null)
            {
                _logger?.Log("Processor not initialized.");
                return;
            }

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            lblRunValue.Text = "Run: Running";

            _cts = new CancellationTokenSource();

            try
            {
                await foreach (var line in _device.ReadLinesAsync(_cts.Token))
                {
                    // NEW: all parsing/scaling/calibration/quality moved out
                    if (!_processor.TryProcess(line, out var result, out var record, out var error))
                    {
                        _logger?.Log("Parse error: " + error);
                        continue;
                    }

                    // Persist (enqueue for background writer)
                    if (_dbWriter is not null && !_dbWriter.TryEnqueue(record))
                        _logger?.Log("DB queue full: measurement dropped");

                    _ui?.Invoke(() =>
                    {
                        ApplyMeasurementToUi(result);
                    });
                }
            }
            catch (OperationCanceledException)
            {
                _logger?.Log("Reading stopped.");
            }
            catch (Exception ex)
            {
                _logger?.Log("Reading error: " + ex.Message);
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;

                lblRunValue.Text = "Run: Stopped";
            }
        }

        private void ApplyMeasurementToUi(MeasurementResult result)
        {
            lblCurrentValueFirst.Text = $"Width: {result.WidthMm:F3} mm   |   Weight: {result.WeightG:F3} g";
            lblLastSampleValue.Text = $"Last sample: {result.Timestamp.ToLocalTime():HH:mm:ss.fff}";

            UpdateStats(result.Quality);

            _rows.Insert(0, new MeasurementRow
            {
                Timestamp = result.Timestamp,
                WidthMm = result.WidthMm,
                WeightG = result.WeightG,
                Status = result.Quality.ToString(),
                Accepted = result.Accepted
            });

            // Color newest row
            if (gridMeasurements.Rows.Count > 0)
            {
                var r = gridMeasurements.Rows[0];

                r.DefaultCellStyle.BackColor = result.Quality switch
                {
                    QualityStatus.Perfect => Color.FromArgb(28, 45, 34),     // green
                    QualityStatus.Acceptable => Color.FromArgb(55, 45, 20),  // yellow
                    QualityStatus.Rejected => Color.FromArgb(50, 28, 30),    // red
                    _ => r.DefaultCellStyle.BackColor
                };

                r.DefaultCellStyle.ForeColor = Color.Gainsboro;
            }

            while (_rows.Count > _maxGridRows)
                _rows.RemoveAt(_rows.Count - 1);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            lblRunValue.Text = "Run: Stopped";
        }

        private void UpdateConnectionStatus(string text)
        {
            lblConnValue.Text = "Connection: " + text;
        }

        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();

            if (_dbWriter is not null)
                await _dbWriter.StopAsync();

            await DisposeDeviceAsync();

            base.OnFormClosing(e);
        }

        private async Task DisposeDeviceAsync()
        {
            if (_device is not null)
            {
                await _device.DisposeAsync();
                _device = null;
            }
        }

        private void UpdateStats(QualityStatus quality)
        {
            _stats.Add(quality);

            double pct(int x) => _stats.Total == 0 ? 0 : (100.0 * x / _stats.Total);

            lblTotalValue.Text = _stats.Total.ToString();
            lblPerfectValue.Text = $"{_stats.Perfect} ({pct(_stats.Perfect):0.0}%)";
            lblAcceptableValue.Text = $"{_stats.Acceptable} ({pct(_stats.Acceptable):0.0}%)";
            lblRejectedValue.Text = $"{_stats.Rejected} ({pct(_stats.Rejected):0.0}%)";

            lblCurrentValue.Text = quality.ToString();
            lblCurrentValue.ForeColor = quality switch
            {
                QualityStatus.Perfect => Color.LightGreen,
                QualityStatus.Acceptable => Color.Gold,
                _ => Color.OrangeRed
            };
        }

        private void ResetStats()
        {
            _stats.Reset();

            lblTotalValue.Text = "0";
            lblPerfectValue.Text = "0 (0%)";
            lblAcceptableValue.Text = "0 (0%)";
            lblRejectedValue.Text = "0 (0%)";

            lblCurrentValue.Text = "-";
            lblCurrentValue.ForeColor = Color.Gainsboro;
        }
    }
}
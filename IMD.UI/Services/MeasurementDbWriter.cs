using System.Threading.Channels;
using IMD.Core.Models;
using IMD.Core.Persistence;

namespace IMD.UI.Services
{
    internal sealed class MeasurementDbWriter : IAsyncDisposable
    {
        private readonly IMeasurementRepository _repo;
        private readonly Channel<MeasurementDbRecord> _queue;

        private CancellationTokenSource? _cts;
        private Task? _worker;

        public event Action<string>? StatusChanged; // e.g. "DB: OK", "DB: ERROR"

        public MeasurementDbWriter(
            IMeasurementRepository repo,
            int capacity = 1000,
            BoundedChannelFullMode fullMode = BoundedChannelFullMode.DropOldest)
        {
            _repo = repo;

            _queue = Channel.CreateBounded<MeasurementDbRecord>(new BoundedChannelOptions(capacity)
            {
                SingleReader = true,
                SingleWriter = false,
                FullMode = fullMode
            });
        }

        public void Start()
        {
            if (_worker is not null) return;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            _worker = Task.Run(async () =>
            {
                try
                {
                    await foreach (var record in _queue.Reader.ReadAllAsync(token))
                    {
                        try
                        {
                            await _repo.AddAsync(record, token);
                            StatusChanged?.Invoke("DB: OK");
                        }
                        catch (Exception ex)
                        {
                            StatusChanged?.Invoke("DB: ERROR - " + ex.Message);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // expected
                }
                catch (Exception ex)
                {
                    StatusChanged?.Invoke("DB: Writer crashed - " + ex.Message);
                }
            }, token);
        }

        public bool TryEnqueue(MeasurementDbRecord record)
            => _queue.Writer.TryWrite(record);

        public async Task StopAsync()
        {
            try { _queue.Writer.TryComplete(); } catch { /* ignore */ }

            if (_cts is not null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }

            if (_worker is not null)
            {
                try { await _worker; } catch { /* ignore */ }
                _worker = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await StopAsync();
        }
    }
}
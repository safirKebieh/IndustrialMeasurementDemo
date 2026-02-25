using System.Net;
using System.Net.Sockets;
using System.Text;

// Simple device simulator for demo purposes (TCP stream of measurements).
Console.WriteLine("IMD Device Simulator starting...");

const int port = 9000;

// Keep these in sync with IMD.Core.Services.ScalingService
const int RawMin = 0;
const int RawMax = 32767;

const double WidthEngMin = 7.0;
const double WidthEngMax = 9.0;

const double WeightEngMin = 0.6;
const double WeightEngMax = 1.4;

var listener = new TcpListener(IPAddress.Any, port);
listener.Start();

Console.WriteLine($"Listening on port {port}...");

var rnd = new Random();

static int InverseScale(double engValue, int rawMin, int rawMax, double engMin, double engMax)
{
    var raw = rawMin + (engValue - engMin) * (rawMax - rawMin) / (engMax - engMin);

    if (raw < rawMin) raw = rawMin;
    if (raw > rawMax) raw = rawMax;

    return (int)Math.Round(raw);
}

while (true)
{
    Console.WriteLine("Waiting for client to connect...");
    using var client = await listener.AcceptTcpClientAsync();
    Console.WriteLine("Client connected.");

    try
    {
        using var stream = client.GetStream();
        using var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };

        while (client.Connected)
        {
            var p = rnd.NextDouble();

            double widthMm;
            double weightG;

            if (p < 0.02)
            {
                // 2% Rejected (outside tolerance band)
                widthMm = rnd.NextDouble() < 0.5
                    ? 7.80 + rnd.NextDouble() * 0.08   // 7.80..7.88 (below 7.90)
                    : 8.12 + rnd.NextDouble() * 0.08;  // 8.12..8.20 (above 8.10)

                weightG = rnd.NextDouble() < 0.5
                    ? 0.80 + rnd.NextDouble() * 0.10   // 0.80..0.90 (below 0.92)
                    : 1.10 + rnd.NextDouble() * 0.10;  // 1.10..1.20 (above 1.08)
            }
            else if (p < 0.22)
            {
                // 20% Acceptable (within tolerance but outside perfect)
                // Width: 7.90..7.95 OR 8.05..8.10
                widthMm = rnd.NextDouble() < 0.5
                    ? 7.90 + rnd.NextDouble() * 0.05
                    : 8.05 + rnd.NextDouble() * 0.05;

                // Weight: 0.92..0.96 OR 1.04..1.08
                weightG = rnd.NextDouble() < 0.5
                    ? 0.92 + rnd.NextDouble() * 0.04
                    : 1.04 + rnd.NextDouble() * 0.04;
            }
            else
            {
                // 78% Perfect (tight band)
                widthMm = 7.95 + rnd.NextDouble() * 0.10; // 7.95..8.05
                weightG = 0.96 + rnd.NextDouble() * 0.08; // 0.96..1.04
            }

            var status = "OK";

            // Protocol: ts;rawWidth;rawWeight;status  (UTC ISO-8601)
            // Convert engineering -> raw (inverse scaling) so UI pipeline remains realistic.
            // NOTE: engMin/engMax here describe the "sensor calibration range", not tolerance.
            int rawWidth = InverseScale(widthMm, RawMin, RawMax, WidthEngMin, WidthEngMax);
            int rawWeight = InverseScale(weightG, RawMin, RawMax, WeightEngMin, WeightEngMax);

            var ts = DateTimeOffset.UtcNow.ToString("O");
            var line = $"{ts};{rawWidth};{rawWeight};{status}";

            await writer.WriteLineAsync(line);
            Console.WriteLine(line);

            await Task.Delay(200);
        }
    }
    catch (IOException)
    {
        Console.WriteLine("Client disconnected (IO). Waiting for new client...");
    }
    catch (SocketException)
    {
        Console.WriteLine("Client disconnected (Socket). Waiting for new client...");
    }
}
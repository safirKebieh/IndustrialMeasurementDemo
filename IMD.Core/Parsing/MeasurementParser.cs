using IMD.Core.Models;
using System.Globalization;

namespace IMD.Core.Parsing
{
    public static class MeasurementParser
    {
        /// <summary>
        /// Parses a device protocol line.
        /// Protocol format: ts;rawWidth;rawWeight;status
        /// Example: 2026-02-14T18:31:22.123Z;18342;9120;OK
        /// </summary>
        public static bool TryParse(string? line, out RawMeasurement measurement, out string error)
        {
            measurement = default!;
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(line))
            {
                error = "Line is empty.";
                return false;
            }

            var parts = line.Trim().Split(';');
            if (parts.Length != 4)
            {
                error = $"Invalid field count. Expected 4, got {parts.Length}.";
                return false;
            }

            if (!DateTimeOffset.TryParse(parts[0], CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                    out var ts))
            {
                error = "Invalid timestamp.";
                return false;
            }

            if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var rawWidth))
            {
                error = "Invalid rawWidth.";
                return false;
            }

            if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out var rawWeight))
            {
                error = "Invalid rawWeight.";
                return false;
            }

            var status = parts[3].Trim();
            if (status.Length == 0)
            {
                error = "Status is empty.";
                return false;
            }

            measurement = new RawMeasurement(ts, rawWidth, rawWeight, status);
            return true;
        }
    }
}

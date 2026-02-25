namespace IMD.UI
{
    public sealed class MeasurementRow
    {
        public DateTimeOffset Timestamp { get; set; }
        public double WidthMm { get; set; }
        public double WeightG { get; set; }

        public string Status { get; set; } = "";     // Perfect / Acceptable / Rejected
        public bool Accepted { get; set; }           // checkbox column
    }
}

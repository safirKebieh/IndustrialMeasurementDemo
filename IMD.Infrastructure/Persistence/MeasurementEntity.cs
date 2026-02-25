namespace IMD.Infrastructure.Persistence;

public sealed class MeasurementEntity
{
    public long Id { get; set; }
    public DateTimeOffset Timestamp { get; set; }

    public int RawWidth { get; set; }
    public int RawWeight { get; set; }

    public double WidthMm { get; set; }
    public double WeightG { get; set; }

    public string Status { get; set; } = "";
    public bool Ok { get; set; }
    public string? Note { get; set; }

}

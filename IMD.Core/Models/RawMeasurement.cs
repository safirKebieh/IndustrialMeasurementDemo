namespace IMD.Core.Models
{
    public sealed record RawMeasurement(DateTimeOffset Timestamp,
                                        int            RawWidth,
                                        int            RawWeight,
                                        string         Status
 );
}

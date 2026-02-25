
namespace IMD.Core.Models
{
    public sealed record MeasurementResult(DateTimeOffset Timestamp,
                                           double         WidthMm,
                                           double         WeightG,
                                           QualityStatus  Quality,
                                           bool           Accepted);
}
namespace IMD.Core.Models;

public sealed record MeasurementDbRecord(DateTimeOffset Timestamp,
                                         int            RawWidth,
                                         int            RawWeight,
                                         double         WidthMm,
                                         double         WeightG,
                                         string         Status,
                                         bool           Ok,
                                         string?        Note
);

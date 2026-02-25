namespace IMD.Core.Models
{
    public sealed class CalibrationSettings
    {
        public double WidthOffset { get; init; } = 0.0;
        public double WidthGain { get; init; } = 1.0;

        public double WeightOffset { get; init; } = 0.0;
        public double WeightGain { get; init; } = 1.0;
    }
}
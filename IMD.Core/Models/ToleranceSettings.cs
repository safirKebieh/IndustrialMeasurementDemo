namespace IMD.Core.Models
{
    public sealed class ToleranceSettings
    {
        // Target (nominal)
        public double TargetWidth { get; init; } = 8.0;
        public double TargetWeight { get; init; } = 1.0;

        // Tight "perfect" band
        public double PerfectWidthTolerance { get; init; } = 0.05;   // ±0.05 mm
        public double PerfectWeightTolerance { get; init; } = 0.04;  // ±0.04 g

        // Wider tolerance band
        public double WidthTolerance { get; init; } = 0.10;      // ±0.10 mm
        public double WeightTolerance { get; init; } = 0.08;     // ±0.08 g
    }
}

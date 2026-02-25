using IMD.Core.Models;

namespace IMD.Core.Services
{
    /// <summary>
    /// Evaluates measurement quality based on configured target values and tolerances.
    /// </summary>
    public sealed class ToleranceService
    {
        private readonly ToleranceSettings _settings;

        public ToleranceService(ToleranceSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Classifies a measurement as Perfect, Acceptable, or Rejected based on tolerances.
        /// Perfect uses the tighter "perfect ranges"; Acceptable uses the broader tolerances.
        /// </summary>
        public QualityStatus Evaluate(double widthMm, double weightG)
        {
            var widthDiff = Math.Abs(widthMm - _settings.TargetWidth);
            var weightDiff = Math.Abs(weightG - _settings.TargetWeight);

            // PERFECT
            if (widthDiff <= _settings.PerfectWidthTolerance &&
                weightDiff <= _settings.PerfectWeightTolerance)
            {
                return QualityStatus.Perfect;
            }

            // ACCEPTABLE
            if (widthDiff <= _settings.WidthTolerance &&
                weightDiff <= _settings.WeightTolerance)
            {
                return QualityStatus.Acceptable;
            }

            // REJECTED
            return QualityStatus.Rejected;
        }

        public bool IsAccepted(QualityStatus status)
            => status != QualityStatus.Rejected;

        public bool IsWidthInTolerance(double widthMm)
            => Math.Abs(widthMm - _settings.TargetWidth) <= _settings.WidthTolerance;

        public bool IsWeightInTolerance(double weightG)
            => Math.Abs(weightG - _settings.TargetWeight) <= _settings.WeightTolerance;

        public bool IsMeasurementOk(double widthMm, double weightG)
            => IsWidthInTolerance(widthMm) && IsWeightInTolerance(weightG);
    }
}

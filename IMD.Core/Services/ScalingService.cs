namespace IMD.Core.Services
{
    /// <summary>
    /// Provides linear scaling from raw device values to engineering units.
    /// </summary>
    public static class ScalingService
    {
        /// <summary>
        /// Maps a raw value from one range into a target engineering range using linear interpolation.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when rawMax equals rawMin.
        /// </exception>
        public static double Scale(
            int rawValue,
            int rawMin,
            int rawMax,
            double engMin,
            double engMax)
        {
            if (rawMax == rawMin)
                throw new ArgumentException("rawMax must be different from rawMin.");

            return engMin + (rawValue - rawMin) * (engMax - engMin) / (rawMax - rawMin);
        }


        /// <summary>
        /// Scales raw width value to millimeters.
        /// Must match simulator inverse scaling ranges.
        /// </summary>
        public static double ScaleWidthMm(int rawWidth)
            => Scale(rawWidth, 0, 32767, 7.0, 9.0);

        /// <summary>
        /// Scales raw weight value to grams.
        /// Must match simulator inverse scaling ranges.
        /// </summary>
        public static double ScaleWeightG(int rawWeight)
            => Scale(rawWeight, 0, 32767, 0.6, 1.4);

    }
}

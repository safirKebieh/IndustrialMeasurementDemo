using System.Runtime.InteropServices;

namespace IMD.Core.Services;

public static class NativeCalibration
{
    private const string DllName = "IMD.NativeCalibration.dll";

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Calibrate(double value, double offset, double gain);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double MovingAverage(double previous, double current, double alpha);
}

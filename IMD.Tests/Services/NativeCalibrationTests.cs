using IMD.Core.Services;
using Xunit;

namespace IMD.Tests.Services;

public class NativeCalibrationTests
{
    [Fact]
    public void Calibrate_AppliesOffsetAndGain()
    {
        var result = NativeCalibration.Calibrate(10.0, offset: 2.0, gain: 3.0);
        Assert.Equal(36.0, result, 6); // (10+2)*3 = 36
    }

    [Fact]
    public void MovingAverage_ComputesExpectedValue()
    {
        var result = NativeCalibration.MovingAverage(previous: 10.0, current: 20.0, alpha: 0.5);
        Assert.Equal(15.0, result, 6);
    }
}

using IMD.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMD.Tests.Services
{
    public class ScalingServiceTests
    {
        [Fact]
        public void ScaleWidth_MinRaw_ReturnsMinEngineering()
        {
            var width = ScalingService.ScaleWidthMm(0);
            Assert.Equal(7.6, width, 3);
        }

        [Fact]
        public void ScaleWidth_MaxRaw_ReturnsMaxEngineering()
        {
            var width = ScalingService.ScaleWidthMm(32767);
            Assert.Equal(8.4, width, 3);
        }

        [Fact]
        public void ScaleWidth_MidRaw_IsAroundTarget()
        {
            var width = ScalingService.ScaleWidthMm(16383);
            Assert.InRange(width, 7.9, 8.1);
        }
    }
}

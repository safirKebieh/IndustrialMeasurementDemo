using IMD.Core.Services;
using IMD.Core.Models;

namespace IMD.Tests.Services
{
    public class ToleranceServiceTests
    {
        private static ToleranceService CreateDefaultService()
            => new ToleranceService(new ToleranceSettings());

        [Fact]
        public void WidthInsideTolerance_ReturnsTrue()
        {
            var svc = CreateDefaultService();

            Assert.True(svc.IsWidthInTolerance(8.05));
        }

        [Fact]
        public void WidthOutsideTolerance_ReturnsFalse()
        {
            var svc = CreateDefaultService();

            Assert.False(svc.IsWidthInTolerance(8.3));
        }

        [Fact]
        public void CombinedMeasurementOk_ReturnsTrue()
        {
            var svc = CreateDefaultService();

            Assert.True(svc.IsMeasurementOk(8.02, 0.98));
        }
    }
}
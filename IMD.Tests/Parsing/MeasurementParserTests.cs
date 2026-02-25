using IMD.Core.Parsing;


namespace IMD.Tests.Parsing
{
    public class MeasurementParserTests
    {
        [Fact]
        public void TryParse_ValidLine_ReturnsTrue()
        {
            // Arrange
            var line = "2026-02-14T18:31:22.123Z;18342;9120;OK";

            // Act
            var ok = MeasurementParser.TryParse(line, out var m, out var error);

            // Assert
            Assert.True(ok);
            Assert.True(string.IsNullOrEmpty(error));
            Assert.Equal(18342, m.RawWidth);
            Assert.Equal(9120, m.RawWeight);
            Assert.Equal("OK", m.Status);
            Assert.Equal(DateTimeOffset.Parse("2026-02-14T18:31:22.123Z"), m.Timestamp);
        }

        [Fact]
        public void TryParse_InvalidFieldCount_ReturnsFalse()
        {
            // Arrange
            var line = "2026-02-14T18:31:22.123Z;18342;OK"; // only 3 fields

            // Act
            var ok = MeasurementParser.TryParse(line, out var _, out var error);

            // Assert
            Assert.False(ok);
            Assert.Contains("field count", error, StringComparison.OrdinalIgnoreCase);
        }
    }
}

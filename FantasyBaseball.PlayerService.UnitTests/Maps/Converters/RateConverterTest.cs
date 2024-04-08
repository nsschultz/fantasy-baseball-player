using Xunit;

namespace FantasyBaseball.PlayerService.Maps.Converters.UnitTests
{
  public class RateConverterTest
  {
    [Theory]
    [InlineData("55", 0.55)]
    [InlineData("75%", 0.75)]
    [InlineData("12 %", 0.12)]
    [InlineData("0.45", 0.45)]
    [InlineData("", 0)]
    [InlineData(null, 0)]
    public void ConvertFromStringTest(string value, double expected) =>
      Assert.Equal(expected, new RateConverter().ConvertFromString(value, null, null));

    [Theory]
    [InlineData(0.2, "0.2")]
    [InlineData("0.2", "0.2")]
    [InlineData(null, "0")]
    public void ConvertToStringTest(object value, string expected) =>
      Assert.Equal(expected, new RateConverter().ConvertToString(value, null, null));
  }
}
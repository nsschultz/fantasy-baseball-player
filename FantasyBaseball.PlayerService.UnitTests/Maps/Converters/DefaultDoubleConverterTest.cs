using Xunit;

namespace FantasyBaseball.PlayerService.Maps.Converters.UnitTests
{
  public class DefaultDoubleConverterTest
  {
    [Theory]
    [InlineData("3.14", 3.14)]
    [InlineData("0", 0)]
    [InlineData("-5.5", -5.5)]
    [InlineData("abc", 0)]
    public void ConvertFromString_ValidString_ReturnsExpectedValue(string input, double expected) =>
      Assert.Equal(expected, new DefaultDoubleConverter().ConvertFromString(input, null, null));


    [Theory]
    [InlineData(3.14, "3.14")]
    [InlineData(0, "0")]
    [InlineData(-5.5, "-5.5")]
    public void ConvertToString_ValidValue_ReturnsExpectedString(double input, string expected) =>
      Assert.Equal(expected, new DefaultDoubleConverter().ConvertToString(input, null, null));
  }
}
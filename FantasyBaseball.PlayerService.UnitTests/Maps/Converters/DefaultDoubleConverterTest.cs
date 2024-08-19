using FantasyBaseball.PlayerService.Maps.Converters;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Maps.Converters
{
  public class DefaultDoubleConverterTest
  {
    [Theory]
    [InlineData("3.14", 3.14)]
    [InlineData("0", 0)]
    [InlineData("-5.5", -5.5)]
    [InlineData("abc", 0)]
    public void ConvertFromStringTest(string input, double expected) =>
      Assert.Equal(expected, new DefaultDoubleConverter().ConvertFromString(input, null, null));


    [Theory]
    [InlineData(3.14, "3.14")]
    [InlineData(0, "0")]
    [InlineData(-5.5, "-5.5")]
    public void ConvertToStringTest(double input, string expected) =>
      Assert.Equal(expected, new DefaultDoubleConverter().ConvertToString(input, null, null));
  }
}
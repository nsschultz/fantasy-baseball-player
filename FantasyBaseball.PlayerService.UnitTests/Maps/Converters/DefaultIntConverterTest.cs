using FantasyBaseball.PlayerService.Maps.Converters;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Maps.Converters
{
  public class DefaultIntConverterTest
  {
    [Theory]
    [InlineData("3", 3)]
    [InlineData("0", 0)]
    [InlineData("-5", -5)]
    [InlineData("-5.5", 0)]
    [InlineData("abc", 0)]
    public void ConvertFromStringTest(string input, int expected) =>
      Assert.Equal(expected, new DefaultIntConverter().ConvertFromString(input, null, null));


    [Theory]
    [InlineData(3, "3")]
    [InlineData(0, "0")]
    [InlineData(-5, "-5")]
    public void ConvertToStringTest(int input, string expected) =>
      Assert.Equal(expected, new DefaultIntConverter().ConvertToString(input, null, null));
  }
}
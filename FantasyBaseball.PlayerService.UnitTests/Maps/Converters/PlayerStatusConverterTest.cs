using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Maps.Converters
{
  public class PlayerStatusConverterTest
  {
    [Theory]
    [InlineData("ne", PlayerStatus.NE)]
    [InlineData(" IL ", PlayerStatus.IL)]
    [InlineData("Not Available", PlayerStatus.NA)]
    [InlineData("", PlayerStatus.XX)]
    [InlineData(null, PlayerStatus.XX)]
    public void ConvertFromStringTest(string value, PlayerStatus expected) =>
      Assert.Equal(expected, new PlayerStatusConverter().ConvertFromString(value, null, null));

    [Theory]
    [InlineData(PlayerStatus.NE, "NE")]
    [InlineData(null, "XX")]
    public void ConvertToStringTest(object value, string expected) =>
      Assert.Equal(expected, new PlayerStatusConverter().ConvertToString(value, null, null));
  }
}
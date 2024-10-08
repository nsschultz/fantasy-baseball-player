using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;
using static FantasyBaseball.PlayerService.Models.Enums.EnumUtility;

namespace FantasyBaseball.PlayerService.UnitTests.Models.Enums
{
  public class PlayerStatusTest
  {
    [Theory]
    [InlineData(PlayerStatus.XX, "")]
    [InlineData(PlayerStatus.IL, "Injured List")]
    [InlineData(PlayerStatus.NA, "Not Available")]
    [InlineData(PlayerStatus.NE, "New Entry")]
    public void GetDescriptionTest(PlayerStatus type, string description) => Assert.Equal(description, GetDescription(type));

    [Theory]
    [InlineData(PlayerStatus.XX, "")]
    [InlineData(PlayerStatus.IL, "INJURED List")]
    [InlineData(PlayerStatus.NA, "NOT Available")]
    [InlineData(PlayerStatus.NE, "New ENTRY")]
    [InlineData(PlayerStatus.XX, "Normal")]
    [InlineData(PlayerStatus.XX, null)]
    public void GetFromDescriptionTest(PlayerStatus type, string desc) => Assert.Equal(type, GetFromDescription<PlayerStatus>(desc));

    [Theory]
    [InlineData(PlayerStatus.XX, "")]
    [InlineData(PlayerStatus.IL, "il")]
    [InlineData(PlayerStatus.NA, "nA")]
    [InlineData(PlayerStatus.NE, "Ne")]
    [InlineData(PlayerStatus.XX, "XX")]
    [InlineData(PlayerStatus.XX, null)]
    public void GetFromKeyTest(PlayerStatus type, string key) => Assert.Equal(type, GetFromKey<PlayerStatus>(key));
  }
}
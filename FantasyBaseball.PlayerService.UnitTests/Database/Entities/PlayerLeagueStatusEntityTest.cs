using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Database.Entities.UnitTests
{
  public class PlayerLeagueStatusEntityTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new PlayerLeagueStatusEntity();
      Assert.Equal(default, obj.PlayerId);
      Assert.Equal(0, obj.LeagueId);
      Assert.Equal(LeagueStatus.A, obj.LeagueStatus);
      Assert.Null(obj.Player);
    }
  }
}
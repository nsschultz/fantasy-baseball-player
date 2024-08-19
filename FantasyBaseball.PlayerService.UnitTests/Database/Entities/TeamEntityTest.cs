using FantasyBaseball.PlayerService.Database.Entities;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Entities
{
  public class TeamEntityTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new TeamEntity();
      Assert.Null(obj.Code);
      Assert.Null(obj.AlternativeCode);
      Assert.Null(obj.LeagueId);
      Assert.Null(obj.City);
      Assert.Null(obj.Nickname);
      Assert.Empty(obj.Players);
    }
  }
}
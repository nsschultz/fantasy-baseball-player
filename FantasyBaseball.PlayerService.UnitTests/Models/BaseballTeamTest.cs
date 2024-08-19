using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Models
{
  public class BaseballTeamTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new BaseballTeam();
      Assert.Null(obj.Code);
      Assert.Null(obj.AlternativeCode);
      Assert.Null(obj.LeagueId);
      Assert.Null(obj.City);
      Assert.Null(obj.Nickname);
    }
  }
}
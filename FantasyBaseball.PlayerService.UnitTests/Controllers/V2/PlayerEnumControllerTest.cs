using System.Collections.Generic;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
  public class PlayerEnumControllerTest
  {
    [Fact]
    public void GetPlayersEnumMapTest()
    {
      var expected = new Dictionary<int, string>() { { 0, "Available" }, { 1, "Rostered" }, { 2, "Unavailable" }, { 3, "Scouted" } };
      var getEnumMapService = new Mock<IGetPlayerEnumMapService>();
      getEnumMapService.Setup(o => o.GetPlayerEnumMap(It.Is<string>(i => "LeagueStatus".Equals(i)))).Returns(expected);
      Assert.Equal(expected, new PlayerEnumController(getEnumMapService.Object).GetPlayersEnumMap("LeagueStatus"));
    }
  }
}
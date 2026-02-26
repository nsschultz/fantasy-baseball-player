using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3;

public class PlayerGetControllerTest
{
  [Fact]
  public async Task GetPlayerTest()
  {
    var id = Guid.NewGuid();
    var getService = new Mock<IGetPlayerService>();
    getService.Setup(o => o.GetPlayer(It.Is<Guid>(i => i == id))).ReturnsAsync(new BaseballPlayer { Id = id });
    var player = await new PlayerGetController(getService.Object).GetPlayer(id);
    Assert.Equal(id, player.Id);
  }

  [Fact]
  public async Task GetPlayersTest()
  {
    var getService = new Mock<IGetPlayerService>();
    getService.Setup(o => o.GetPlayers()).ReturnsAsync([new BaseballPlayer()]);
    Assert.NotEmpty(await new PlayerGetController(getService.Object).GetPlayers());
  }
}
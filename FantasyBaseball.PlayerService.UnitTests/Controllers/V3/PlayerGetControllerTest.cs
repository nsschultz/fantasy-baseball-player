using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Controllers.V3;
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
        getService.Setup(o => o.GetPlayer(It.Is<Guid>(i => i == id))).ReturnsAsync(new Player { Id = id });
        var player = await new PlayerGetController(getService.Object).GetPlayer(id);
        Assert.Equal(id, player.Id);
    }

    [Fact]
    public async Task GetPlayersTest()
    {
        var getService = new Mock<IGetPlayerService>();
        getService.Setup(o => o.GetPlayers()).ReturnsAsync([new Player()]);
        Assert.NotEmpty(await new PlayerGetController(getService.Object).GetPlayers());
    }
}
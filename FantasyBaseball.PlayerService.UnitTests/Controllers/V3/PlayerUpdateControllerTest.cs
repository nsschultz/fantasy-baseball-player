using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3;

public class PlayerUpdateControllerTest
{
    [Fact]
    public async Task UpdatePlayerTest()
    {
        var id = Guid.NewGuid();
        var updateService = new Mock<IUpdatePlayerService>();
        updateService.Setup(o => o.UpdatePlayer(It.Is<Player>(p => p.Id == id))).Returns(Task.FromResult(0));
        await new PlayerUpdateController(updateService.Object).UpdatePlayer(id, new Player { Id = id });
        updateService.VerifyAll();
    }

    [Fact]
    public async Task UpdatePlayerTestDifferentPlayerIds() =>
      await Assert.ThrowsAsync<BadRequestException>(() =>
        new PlayerUpdateController(null).UpdatePlayer(Guid.NewGuid(), new Player { Id = Guid.NewGuid() }));

    [Fact]
    public async Task UpdatePlayersTestEmptyPlayerId() =>
      await Assert.ThrowsAsync<BadRequestException>(() => new PlayerUpdateController(null).UpdatePlayer(Guid.Empty, new Player()));

    [Fact]
    public async Task UpdatePlayerTestNullPlayer() =>
      await Assert.ThrowsAsync<BadRequestException>(() => new PlayerUpdateController(null).UpdatePlayer(Guid.NewGuid(), null));
}
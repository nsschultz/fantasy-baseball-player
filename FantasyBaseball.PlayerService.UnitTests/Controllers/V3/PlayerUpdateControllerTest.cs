using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
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
    updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayer>(p => p.Id == id))).Returns(Task.FromResult(0));
    await new PlayerUpdateController(updateService.Object).UpdatePlayer(id, new BaseballPlayer { Id = id });
    updateService.VerifyAll();
  }

  [Fact]
  public async Task UpdatePlayerTestDifferentPlayerIds() =>
    await Assert.ThrowsAsync<BadRequestException>(() =>
      new PlayerUpdateController(null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayer { Id = Guid.NewGuid() }));

  [Fact]
  public async Task UpdatePlayersTestEmptyPlayerId() =>
    await Assert.ThrowsAsync<BadRequestException>(() => new PlayerUpdateController(null).UpdatePlayer(Guid.Empty, new BaseballPlayer()));

  [Fact]
  public async Task UpdatePlayerTestNullPlayer() =>
    await Assert.ThrowsAsync<BadRequestException>(() => new PlayerUpdateController(null).UpdatePlayer(Guid.NewGuid(), null));
}
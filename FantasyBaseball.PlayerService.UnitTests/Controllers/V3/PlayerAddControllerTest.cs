using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3;

public class PlayerAddControllerTest
{
  [Fact]
  public async Task AddPlayerTest()
  {
    var id = Guid.NewGuid();
    var addService = new Mock<IAddPlayerService>();
    addService.Setup(o => o.AddPlayer(It.IsAny<BaseballPlayer>())).ReturnsAsync(id);
    var newId = await new PlayerAddController(addService.Object).AddPlayer(new BaseballPlayer { });
    Assert.Equal(id, newId);
  }

  [Fact]
  public async Task AddPlayerTestExistingPlayerId() =>
    await Assert.ThrowsAsync<BadRequestException>(() => new PlayerAddController(null).AddPlayer(new BaseballPlayer { Id = Guid.NewGuid() }));

  [Fact]
  public async Task AddPlayerTestNullPlayer() => await Assert.ThrowsAsync<BadRequestException>(() => new PlayerAddController(null).AddPlayer(null));
}
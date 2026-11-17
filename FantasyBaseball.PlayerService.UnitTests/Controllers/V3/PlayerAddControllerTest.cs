using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Controllers.V3;
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
    addService.Setup(o => o.AddPlayer(It.IsAny<Player>())).ReturnsAsync(id);
    var newId = await new PlayerAddController(addService.Object).AddPlayer(new Player { });
    Assert.Equal(id, newId);
  }

  [Fact]
  public async Task AddPlayerTestExistingPlayerId() =>
    await Assert.ThrowsAsync<BadRequestException>(() => new PlayerAddController(null).AddPlayer(new Player { Id = Guid.NewGuid() }));

  [Fact]
  public async Task AddPlayerTestNullPlayer() => await Assert.ThrowsAsync<BadRequestException>(() => new PlayerAddController(null).AddPlayer(null));
}
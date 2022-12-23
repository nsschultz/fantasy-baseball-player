using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
  public class PlayerControllerTest
  {
    [Fact]
    public async void DeleteAllPlayersTest()
    {
      var playerRepo = new Mock<IPlayerRepository>();
      await new PlayerController(playerRepo.Object, null, null).DeleteAllPlayers();
      playerRepo.VerifyAll();
    }

    [Fact]
    public async void GetPlayersTest()
    {
      var getService = new Mock<IGetPlayersService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayerV2> { new BaseballPlayerV2() });
      Assert.NotEmpty((await new PlayerController(null, getService.Object, null).GetPlayers()));
    }

    [Fact]
    public async void UpdatePlayersTest()
    {
      var id = Guid.NewGuid();
      var updateService = new Mock<IUpdatePlayerService>();
      updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayerV2>(p => p.Id == id))).Returns(Task.FromResult(0));
      await new PlayerController(null, null, updateService.Object).UpdatePlayer(id, new BaseballPlayerV2 { Id = id });
      updateService.VerifyAll();
    }

    [Fact]
    public void UpdatePlayersTestDifferentPlayerIds() =>
      Assert.ThrowsAsync<BadRequestException>(() =>
        new PlayerController(null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayerV2 { Id = Guid.NewGuid() }));

    [Fact]
    public void UpdatePlayersTestEmptyPlayerId() =>
      Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayerV2()));

    [Fact]
    public void UpdatePlayersTestNullPlayer() =>
      Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null).UpdatePlayer(Guid.NewGuid(), null));
  }
}
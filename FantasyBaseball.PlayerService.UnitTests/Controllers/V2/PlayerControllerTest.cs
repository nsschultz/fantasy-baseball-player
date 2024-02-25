using System;
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
    public async void AddPlayerTest()
    {
      var id = Guid.NewGuid();
      var addService = new Mock<IAddPlayerService>();
      addService.Setup(o => o.AddPlayer(It.IsAny<BaseballPlayer>())).ReturnsAsync(id);
      var newId = await new PlayerController(null, addService.Object, null, null, null).AddPlayer(new BaseballPlayer { });
      Assert.Equal(id, newId);
    }

    [Fact]
    public async void AddPlayerTestExistingPlayerId() =>
      await Assert.ThrowsAsync<BadRequestException>(() =>
        new PlayerController(null, null, null, null, null).AddPlayer(new BaseballPlayer { Id = Guid.NewGuid() }));

    [Fact]
    public async void AddPlayerTestNullPlayer() =>
      await Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).AddPlayer(null));

    [Fact]
    public async void DeleteAllPlayersTest()
    {
      var playerRepo = new Mock<IPlayerRepository>();
      await new PlayerController(playerRepo.Object, null, null, null, null).DeleteAllPlayers();
      playerRepo.VerifyAll();
    }

    [Fact]
    public async void DeletePlayerTest()
    {
      var id = Guid.NewGuid();
      var deleteService = new Mock<IDeletePlayerService>();
      deleteService.Setup(o => o.DeletePlayer(It.Is<Guid>(i => i == id))).Returns(Task.FromResult(0));
      await new PlayerController(null, null, deleteService.Object, null, null).DeletePlayer(id);
      deleteService.VerifyAll();
    }

    [Fact]
    public async void GetPlayerTest()
    {
      var id = Guid.NewGuid();
      var getService = new Mock<IGetPlayerService>();
      getService.Setup(o => o.GetPlayer(It.Is<Guid>(i => i == id))).ReturnsAsync(new BaseballPlayer { Id = id });
      var player = await new PlayerController(null, null, null, getService.Object, null).GetPlayer(id);
      Assert.Equal(id, player.Id);
    }

    [Fact]
    public async void GetPlayersTest()
    {
      var getService = new Mock<IGetPlayerService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync([new BaseballPlayer()]);
      Assert.NotEmpty(await new PlayerController(null, null, null, getService.Object, null).GetPlayers());
    }

    [Fact]
    public async void UpdatePlayerTest()
    {
      var id = Guid.NewGuid();
      var updateService = new Mock<IUpdatePlayerService>();
      updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayer>(p => p.Id == id))).Returns(Task.FromResult(0));
      await new PlayerController(null, null, null, null, updateService.Object).UpdatePlayer(id, new BaseballPlayer { Id = id });
      updateService.VerifyAll();
    }

    [Fact]
    public async void UpdatePlayerTestDifferentPlayerIds() =>
      await Assert.ThrowsAsync<BadRequestException>(() =>
        new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayer { Id = Guid.NewGuid() }));

    [Fact]
    public async void UpdatePlayersTestEmptyPlayerId() =>
      await Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayer()));

    [Fact]
    public async void UpdatePlayerTestNullPlayer() =>
      await Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), null));
  }
}
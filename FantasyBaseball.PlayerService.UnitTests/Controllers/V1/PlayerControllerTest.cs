using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V1.UnitTests
{
  public class PlayerControllerTest
  {
    private IMapper _mapper;

    public PlayerControllerTest() => _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerV1Profile())).CreateMapper();

    [Fact]
    public async void DeleteAllPlayersTest()
    {
      var playerRepo = new Mock<IPlayerRepository>();
      await new PlayerController(null, playerRepo.Object, null, null).DeleteAllPlayers();
      playerRepo.VerifyAll();
    }

    [Fact]
    public async void GetPlayersTest()
    {
      var getService = new Mock<IGetPlayersService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayerV2> { new BaseballPlayerV2() });
      Assert.NotEmpty((await new PlayerController(_mapper, null, getService.Object, null).GetPlayers()));
    }

    [Fact] public void MergePlayersTest() => Assert.Throws<BadRequestException>(() => new PlayerController(null, null, null, null).MergePlayers());

    [Fact]
    public async void UpdatePlayersTest()
    {
      var id = Guid.NewGuid();
      var updateService = new Mock<IUpdatePlayerService>();
      updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayerV2>(p => p.Id == id))).Returns(Task.FromResult(0));
      await new PlayerController(_mapper, null, null, updateService.Object).UpdatePlayer(id, new BaseballPlayerV1 { Id = id });
      updateService.VerifyAll();
    }

    [Fact]
    public void UpdatePlayersTestDifferentPlayerIds() =>
      Assert.ThrowsAsync<BadRequestException>(() =>
        new PlayerController(null, null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayerV1 { Id = Guid.NewGuid() }));

    [Fact]
    public void UpdatePlayersTestEmptyPlayerId() =>
      Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayerV1()));

    [Fact]
    public void UpdatePlayersTestNullPlayer() =>
      Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null).UpdatePlayer(Guid.NewGuid(), null));
  }
}
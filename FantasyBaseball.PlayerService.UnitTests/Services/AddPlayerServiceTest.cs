using System;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services
{
  public class AddPlayerServiceTest
  {
    [Fact]
    public async void AddPlayerTestExistingIdException()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = new BaseballPlayer { MlbAmId = 100, Type = PlayerType.B };
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerByMlbAmId(It.Is<int>(i => i == 100), It.Is<PlayerType>(t => t == PlayerType.B))).ReturnsAsync(new PlayerEntity { });
      await Assert.ThrowsAsync<BadRequestException>(async () => await new AddPlayerService(mapper, playerRepo.Object).AddPlayer(player));
    }

    [Fact]
    public async void AddPlayerTestValid()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var id = Guid.NewGuid();
      var player = new BaseballPlayer { Id = id, MlbAmId = 100, Type = PlayerType.B };
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerByMlbAmId(It.Is<int>(i => i == 100), It.Is<PlayerType>(t => t == PlayerType.B))).ReturnsAsync((PlayerEntity)null);
      playerRepo.Setup(o => o.AddPlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(0));
      var newId = await new AddPlayerService(mapper, playerRepo.Object).AddPlayer(player);
      Assert.Equal(id, newId);
    }
  }
}
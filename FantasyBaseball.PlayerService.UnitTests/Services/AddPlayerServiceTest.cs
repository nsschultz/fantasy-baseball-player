using System;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services;

public class AddPlayerServiceTest
{
  [Fact]
  public async Task AddPlayerTestExistingIdException()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile()), new LoggerFactory()).CreateMapper();
    var player = new Player { MlbAmId = 100, Type = PlayerType.B };
    var playerRepo = new Mock<IPlayerRepository>();
    playerRepo.Setup(o => o.GetPlayerByMlbAmId(It.Is<int>(i => i == 100), It.Is<PlayerType>(t => t == PlayerType.B))).ReturnsAsync(new PlayerEntity { });
    await Assert.ThrowsAsync<BadRequestException>(async () => await new AddPlayerService(mapper, playerRepo.Object).AddPlayer(player));
  }

  [Fact]
  public async Task AddPlayerTestValid()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile()), new LoggerFactory()).CreateMapper();
    var id = Guid.NewGuid();
    var player = new Player { Id = id, MlbAmId = 100, Type = PlayerType.B };
    var playerRepo = new Mock<IPlayerRepository>();
    playerRepo.Setup(o => o.GetPlayerByMlbAmId(It.Is<int>(i => i == 100), It.Is<PlayerType>(t => t == PlayerType.B))).ReturnsAsync((PlayerEntity)null);
    playerRepo.Setup(o => o.AddPlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(0));
    var newId = await new AddPlayerService(mapper, playerRepo.Object).AddPlayer(player);
    Assert.Equal(id, newId);
  }
}
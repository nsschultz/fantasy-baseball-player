using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using FantasyBaseball.PlayerService.Services.Mergers;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services
{
  public class UpdatePlayerServiceTest
  {
    [Fact]
    public async void UpdatePlayerTestChangedTypeException()
    {
      var id = Guid.NewGuid();
      var entity = new PlayerEntity { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = "MIL" };
      var player = new BaseballPlayer { Id = id, MlbAmId = 1, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } };
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).ReturnsAsync(entity);
      await Assert.ThrowsAsync<BadRequestException>(async () => await new UpdatePlayerService(playerRepo.Object, null).UpdatePlayer(player));
    }

    [Fact]
    public async void UpdatePlayerTestMissingIdException()
    {
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).ReturnsAsync((PlayerEntity)null);
      var player = new BaseballPlayer { Id = Guid.NewGuid(), MlbAmId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } };
      await Assert.ThrowsAsync<BadRequestException>(async () => await new UpdatePlayerService(playerRepo.Object, null).UpdatePlayer(player));
    }

    [Fact]
    public async void UpdatePlayerTestValid()
    {
      var id = Guid.NewGuid();
      var entity = new PlayerEntity { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = "MIL" };
      var player = new BaseballPlayer { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } };
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).ReturnsAsync(entity);
      playerRepo.Setup(o => o.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(0));
      var mergeService = new Mock<IMergePlayerService>();
      mergeService
        .Setup(o => o.MergePlayer(It.IsAny<IPlayerMerger>(), It.IsAny<BaseballPlayer>(), It.IsAny<PlayerEntity>()))
        .Returns(Task.FromResult(entity));
      await new UpdatePlayerService(playerRepo.Object, mergeService.Object).UpdatePlayer(player);
      playerRepo.Verify(x => x.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id)), Times.Once);
    }
  }
}
using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Services;
using FantasyBaseball.PlayerService.Services.Mergers;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services;

public class UpdatePlayerServiceTest
{
    [Fact]
    public async Task UpdatePlayerTestChangedTypeException()
    {
        var id = Guid.NewGuid();
        var entity = new PlayerEntity { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = "MIL" };
        var player = new Player { Id = id, MlbAmId = 1, Type = PlayerType.P, Team = new PlayerTeam { Code = "MIL" } };
        var playerRepo = new Mock<IPlayerRepository>();
        playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).ReturnsAsync(entity);
        await Assert.ThrowsAsync<BadRequestException>(async () => await new UpdatePlayerService(playerRepo.Object, null).UpdatePlayer(player));
    }

    [Fact]
    public async Task UpdatePlayerTestMissingIdException()
    {
        var playerRepo = new Mock<IPlayerRepository>();
        playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).ReturnsAsync((PlayerEntity)null);
        var player = new Player { Id = Guid.NewGuid(), MlbAmId = 1, Type = PlayerType.B, Team = new PlayerTeam { Code = "MIL" } };
        await Assert.ThrowsAsync<BadRequestException>(async () => await new UpdatePlayerService(playerRepo.Object, null).UpdatePlayer(player));
    }

    [Fact]
    public async Task UpdatePlayerTestValid()
    {
        var id = Guid.NewGuid();
        var entity = new PlayerEntity { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = "MIL" };
        var player = new Player { Id = id, MlbAmId = 1, Type = PlayerType.B, Team = new PlayerTeam { Code = "MIL" } };
        var playerRepo = new Mock<IPlayerRepository>();
        playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).ReturnsAsync(entity);
        playerRepo.Setup(o => o.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(0));
        var mergeService = new Mock<IMergePlayerService>();
        mergeService
          .Setup(o => o.MergePlayer(It.IsAny<IPlayerMerger>(), It.IsAny<Player>(), It.IsAny<PlayerEntity>()))
          .Returns(Task.FromResult(entity));
        await new UpdatePlayerService(playerRepo.Object, mergeService.Object).UpdatePlayer(player);
        playerRepo.Verify(x => x.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id)), Times.Once);
    }
}
using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class PlayerUpdateServiceTest
    {
        [Fact]
        public async void UpdatePlayerTestMissingIdException()
        {
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).Returns(Task.FromResult<PlayerEntity>(null));
            var player = new BaseballPlayer { Id = Guid.NewGuid(), BhqId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } };
            await Assert.ThrowsAsync<BadRequestException>(async () => await new PlayerUpdateService(playerRepo.Object, null).UpdatePlayer(player));
        }

        [Fact]
        public async void UpdatePlayerTestValid()
        {
            var id = Guid.NewGuid();
            var entity = new PlayerEntity { Id = id, BhqId = 1, Type = PlayerType.B, Team = "MIL" };
            var player = new BaseballPlayer { Id = id, BhqId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } };
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).Returns(Task.FromResult(entity));
            playerRepo.Setup(o => o.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(entity));
            var mergeService = new Mock<IPlayerEntityMergerService>();
            mergeService.Setup(o => o.MergePlayerEntity(It.IsAny<BaseballPlayer>(), It.IsAny<PlayerEntity>())).Returns(Task.FromResult(entity));
            await new PlayerUpdateService(playerRepo.Object, mergeService.Object).UpdatePlayer(player);
            playerRepo.Verify(x => x.UpdatePlayer(It.Is<PlayerEntity>(p => p.Id == id)), Times.Once);
        }
    }
}
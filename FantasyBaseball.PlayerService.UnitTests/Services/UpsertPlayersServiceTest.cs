using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class UpsertPlayerServiceTest
    {
        [Fact]
        public async void UpsertPlayersTestValid()
        {
            var mergeService = new Mock<IPlayerEntityMergerService>();
            mergeService.Setup(o => o.MergePlayerEntity(It.IsAny<BaseballPlayerV2>(), It.IsAny<PlayerEntity>())).Returns(Task.FromResult(new PlayerEntity()));
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).Returns(Task.FromResult(new PlayerEntity()));
            playerRepo.Setup(o => o.GetPlayerByBhqId(It.IsAny<int>(), It.IsAny<PlayerType>())).Returns(Task.FromResult(new PlayerEntity()));
            playerRepo.Setup(o => o.UpsertPlayers(It.Is<IEnumerable<PlayerEntity>>(e => e.Count() == 5))).Returns(Task.CompletedTask);
            var values = new List<BaseballPlayerV2>
            {
                new BaseballPlayerV2 { BhqId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayerV2 { BhqId = 2, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayerV2 { BhqId = 4, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayerV2 { Id = Guid.NewGuid(), BhqId = 5, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayerV2 { Id = Guid.NewGuid(), BhqId = 1, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
            };
            await new UpsertPlayersService(playerRepo.Object, mergeService.Object).UpsertPlayers(values);
            playerRepo.Verify(x => x.GetPlayerById(It.IsAny<Guid>()), Times.Exactly(2));
            playerRepo.Verify(x => x.GetPlayerByBhqId(It.IsAny<int>(), It.IsAny<PlayerType>()), Times.Exactly(3));
            playerRepo.Verify(x => x.UpsertPlayers(It.Is<IEnumerable<PlayerEntity>>(e => e.Count() == 5)), Times.Once);
        }
    }
}
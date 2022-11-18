using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class UpdatePlayerServiceTest
    {
        [Fact]
        public async void UpsertPlayersTestValid()
        {
            var mergeService = new Mock<IPlayerEntityMergerService>();
            mergeService.Setup(o => o.MergePlayerEntity(It.IsAny<BaseballPlayer>(), It.IsAny<PlayerEntity>())).Returns(Task.FromResult(new PlayerEntity()));
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).Returns(Task.FromResult(new PlayerEntity()));
            playerRepo.Setup(o => o.GetPlayerByBhqId(It.IsAny<int>(), It.IsAny<PlayerType>())).Returns(Task.FromResult(new PlayerEntity()));
            playerRepo.Setup(o => o.UpsertPlayers(It.Is<IEnumerable<PlayerEntity>>(e => e.Count() == 5))).Returns(Task.CompletedTask);
            var values = new List<BaseballPlayer>
            {
                new BaseballPlayer { BhqId = 1, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayer { BhqId = 2, Type = PlayerType.B, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayer { BhqId = 4, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayer { Id = Guid.NewGuid(), BhqId = 5, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
                new BaseballPlayer { Id = Guid.NewGuid(), BhqId = 1, Type = PlayerType.P, Team = new BaseballTeam { Code = "MIL" } },
            };
            await new UpsertPlayersService(playerRepo.Object, mergeService.Object).UpsertPlayers(values);
            playerRepo.Verify(x => x.GetPlayerById(It.IsAny<Guid>()), Times.Exactly(2));
            playerRepo.Verify(x => x.GetPlayerByBhqId(It.IsAny<int>(), It.IsAny<PlayerType>()), Times.Exactly(3));
            playerRepo.Verify(x => x.UpsertPlayers(It.Is<IEnumerable<PlayerEntity>>(e => e.Count() == 5)), Times.Once);
        }
    }
}
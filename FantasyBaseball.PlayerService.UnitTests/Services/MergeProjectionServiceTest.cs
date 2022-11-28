using System.Collections.Generic;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services.Mergers;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class MergeProjectionServiceTest
    {
        [Fact]
        public async Task MergeProjectionEmpty()
        {
            var returnList = new List<CsvBaseballPlayer>();
            var fileService = new Mock<ICsvFileReaderService>();
            fileService.Setup(o => o.ReadCsvData(It.IsAny<ClassMap>(), It.IsAny<IFileReader>())).ReturnsAsync(returnList);
            Assert.Equal(0, await new MergeProjectionService(null, fileService.Object, null).MergeProjection(null, PlayerType.B));
        }

        [Fact]
        public async Task MergeProjectionValid()
        {
            var oldPlayers = new List<PlayerEntity>
            {
                new PlayerEntity { BhqId = 000, Type = PlayerType.B },
                new PlayerEntity { BhqId = 456, Type = PlayerType.P },
                new PlayerEntity { BhqId = 789, Type = PlayerType.P }
            };
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayers(It.Is<PlayerType>(i => i == PlayerType.B))).ReturnsAsync(oldPlayers);
            playerRepo.Setup(o => o.UpsertPlayers(It.Is<List<PlayerEntity>>(i => i.Count == 5))).Returns(Task.FromResult(0));
            var newPlayers = new List<CsvBaseballPlayer>
            {
                new CsvBaseballPlayer { BhqId = 123, Type = PlayerType.B },
                new CsvBaseballPlayer { BhqId = 456, Type = PlayerType.P },
                new CsvBaseballPlayer { BhqId = 789, Type = PlayerType.U }
            };
            var fileService = new Mock<ICsvFileReaderService>();
            fileService.Setup(o => o.ReadCsvData(It.IsAny<ClassMap>(), It.IsAny<IFileReader>())).ReturnsAsync(newPlayers);
            var mergeService = new Mock<IMergePlayerService>();
            mergeService
                .Setup(o => o.MergePlayer(It.IsAny<BhqPlayerMerger>(), It.IsAny<BaseballPlayerV2>(), It.IsAny<PlayerEntity>()))
                .ReturnsAsync(new PlayerEntity());
            Assert.Equal(3, await new MergeProjectionService(playerRepo.Object, fileService.Object, mergeService.Object).MergeProjection(null, PlayerType.B));
            playerRepo.VerifyAll();
        }
    }
}
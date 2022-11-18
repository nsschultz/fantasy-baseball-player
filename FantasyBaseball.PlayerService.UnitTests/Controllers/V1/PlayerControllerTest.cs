using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Repositories;
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
            await new PlayerController(null, playerRepo.Object, null, null, null).DeleteAllPlayers();
            playerRepo.VerifyAll();
        }

        [Fact]
        public async void GetPlayersTest()
        {
            var getService = new Mock<IGetPlayersService>();
            getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayer> { new BaseballPlayer() });
            Assert.NotEmpty((await new PlayerController(_mapper, null, getService.Object, null, null).GetPlayers()));
        }

        [Fact]
        public async void UpdatePlayersTest()
        {
            var id = Guid.NewGuid();
            var updateService = new Mock<IPlayerUpdateService>();
            updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayer>(p => p.Id == id))).Returns(Task.FromResult(0));
            await new PlayerController(_mapper, null, null, updateService.Object, null).UpdatePlayer(id, new BaseballPlayerV1 { Id = id });
            updateService.VerifyAll();
        }

        [Fact]
        public void UpdatePlayersTestDifferentPlayerIds() =>
            Assert.ThrowsAsync<BadRequestException>(() =>
                new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayerV1 { Id = Guid.NewGuid() }));

        [Fact]
        public void UpdatePlayersTestEmptyPlayerId() =>
            Assert.ThrowsAsync<BadRequestException>(() =>
                new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayerV1()));

        [Fact]
        public void UpdatePlayersTestNullPlayer() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), null));

        [Fact]
        public async void UpsertPlayersTest()
        {
            var upsertService = new Mock<IUpsertPlayersService>();
            upsertService.Setup(o => o.UpsertPlayers(It.Is<List<BaseballPlayer>>(l => l.Count == 3))).Returns(Task.FromResult(0));
            var input = new List<BaseballPlayerV1> { new BaseballPlayerV1(), null, new BaseballPlayerV1() };
            await new PlayerController(_mapper, null, null, null, upsertService.Object).UpsertPlayers(input);
            upsertService.VerifyAll();
        }

        [Fact]
        public void UpsertPlayersTestNullPlayerCollection() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpsertPlayers(null));
    }
}
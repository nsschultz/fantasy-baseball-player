using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
    public class PlayerControllerTest
    {
        [Fact]
        public async void DeleteAllPlayersTest()
        {
            var clearPlayerService = new Mock<IClearPlayerService>();
            await new PlayerController(clearPlayerService.Object, null, null, null).DeleteAllPlayers();
            clearPlayerService.VerifyAll();
        }

        [Fact]
        public async void GetPlayersTest()
        {
            var getService = new Mock<IGetPlayersService>();
            getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayer> { new BaseballPlayer() });
            Assert.NotEmpty((await new PlayerController(null, getService.Object, null, null).GetPlayers()));
        }

        [Fact]
        public async void UpdatePlayersTest()
        {
            var id = Guid.NewGuid();
            var updateService = new Mock<IPlayerUpdateService>();
            updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayer>(p => p.Id == id))).Returns(Task.FromResult(0));
            await new PlayerController(null, null, updateService.Object, null).UpdatePlayer(id, new BaseballPlayer { Id = id });
            updateService.VerifyAll();
        }

        [Fact]
        public void UpdatePlayersTestDifferentPlayerIds() =>
            Assert.ThrowsAsync<BadRequestException>(() =>
                new PlayerController(null, null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayer { Id = Guid.NewGuid() }));

        [Fact]
        public void UpdatePlayersTestEmptyPlayerId() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayer()));

        [Fact]
        public void UpdatePlayersTestNullPlayer() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null).UpdatePlayer(Guid.NewGuid(), null));

        [Fact]
        public async void UpsertPlayersTest()
        {
            var upsertService = new Mock<IUpsertPlayersService>();
            upsertService.Setup(o => o.UpsertPlayers(It.Is<List<BaseballPlayer>>(l => l.Count == 3))).Returns(Task.FromResult(0));
            var input = new List<BaseballPlayer> { new BaseballPlayer(), null, new BaseballPlayer() };
            await new PlayerController(null, null, null, upsertService.Object).UpsertPlayers(input);
            upsertService.VerifyAll();
        }

        [Fact]
        public void UpsertPlayersTestNullPlayerCollection() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null).UpsertPlayers(null));
    }
}
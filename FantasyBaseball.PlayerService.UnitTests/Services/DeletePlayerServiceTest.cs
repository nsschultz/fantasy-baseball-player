using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models.Enums;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
  public class DeletePlayerServiceTest
  {
    [Fact]
    public async void DeletePlayerTestMissingIdException()
    {
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).ReturnsAsync((PlayerEntity)null);
      await Assert.ThrowsAsync<BadRequestException>(async () => await new DeletePlayerService(playerRepo.Object).DeletePlayer(Guid.NewGuid()));
    }

    [Fact]
    public async void UpdatePlayerTestValid()
    {
      var id = Guid.NewGuid();
      var entity = new PlayerEntity { Id = id, BhqId = 1, Type = PlayerType.B, Team = "MIL" };
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>(i => i == id))).ReturnsAsync(entity);
      playerRepo.Setup(o => o.DeletePlayer(It.Is<PlayerEntity>(p => p.Id == id))).Returns(Task.FromResult(0));
      await new DeletePlayerService(playerRepo.Object).DeletePlayer(id);
      playerRepo.Verify(x => x.DeletePlayer(It.Is<PlayerEntity>(p => p.Id == id)), Times.Once);
    }
  }
}
using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3
{
  public class PlayerControllerTest
  {
    [Fact]
    public async void DeleteAllPlayersTest()
    {
      var deleteService = new Mock<IDeletePlayerService>();
      await new PlayerDeleteController(deleteService.Object).DeleteAllPlayers();
      deleteService.VerifyAll();
    }

    [Fact]
    public async void DeletePlayerTest()
    {
      var id = Guid.NewGuid();
      var deleteService = new Mock<IDeletePlayerService>();
      deleteService.Setup(o => o.DeletePlayer(It.Is<Guid>(i => i == id))).Returns(Task.FromResult(0));
      await new PlayerDeleteController(deleteService.Object).DeletePlayer(id);
      deleteService.VerifyAll();
    }
  }
}
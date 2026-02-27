using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3;

public class PlayerTeamControllerTest
{
  [Fact]
  public async Task GetTeamsTest()
  {
    var teams = new List<TeamEntity> { new(), new() };
    var mapper = new Mock<IMapper>();
    mapper.Setup(o => o.Map<BaseballTeam>(It.IsAny<TeamEntity>())).Returns(new BaseballTeam());
    var getTeamsService = new Mock<IGetTeamsService>();
    getTeamsService.Setup(o => o.GetTeams()).ReturnsAsync(teams);
    Assert.Equal(teams.Count, (await new PlayerTeamController(mapper.Object, getTeamsService.Object).GetTeams()).Count);
  }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Entities;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
    public class PlayerTeamControllerTest
    {
        [Fact]
        public async Task GetTeamsTest()
        {
            var teams = new List<TeamEntity> { new TeamEntity(), new TeamEntity() };
            var mapper = new Mock<IMapper>();
            mapper.Setup(o => o.Map<BaseballTeam>(It.IsAny<TeamEntity>())).Returns(new BaseballTeam());
            var getTeamsService = new Mock<IGetTeamsService>();
            getTeamsService.Setup(o => o.GetTeams()).Returns(Task.FromResult(teams));
            Assert.Equal(teams.Count, (await new PlayerTeamController(mapper.Object, getTeamsService.Object).GetTeams()).Count);
        }
    }
}
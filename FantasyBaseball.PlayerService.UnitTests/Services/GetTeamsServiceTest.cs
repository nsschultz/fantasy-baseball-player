using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using LazyCache;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class GetTeamsServiceTest
    {
        private static readonly List<TeamEntity> TEAMS = new List<TeamEntity>
        {
            new TeamEntity { Code = ""   , LeagueId = ""  , City = "Free Agent"   , Nickname = "Free Agent"                            },
            new TeamEntity { Code = "BAL", LeagueId = "AL", City = "Baltimore"    , Nickname = "Orioles"                               },
            new TeamEntity { Code = "BOS", LeagueId = "AL", City = "Boston"       , Nickname = "Red Sox"                               },
            new TeamEntity { Code = "NYY", LeagueId = "AL", City = "New York"     , Nickname = "Yankees"                               },
            new TeamEntity { Code = "TB" , LeagueId = "AL", City = "Tampa Bay"    , Nickname = "Rays"       , AlternativeCode = "TAM"  },
            new TeamEntity { Code = "TOR", LeagueId = "AL", City = "Toronto"      , Nickname = "Blue Jays"                             },
            new TeamEntity { Code = "CWS", LeagueId = "AL", City = "Chicago"      , Nickname = "White Sox"  , AlternativeCode = "CHW"  },
            new TeamEntity { Code = "CLE", LeagueId = "AL", City = "Cleveland"    , Nickname = "Indians"                               },
            new TeamEntity { Code = "DET", LeagueId = "AL", City = "Detriot"      , Nickname = "Tigers"                                },
            new TeamEntity { Code = "KC" , LeagueId = "AL", City = "Kansas City"  , Nickname = "Royals"                                },
            new TeamEntity { Code = "MIN", LeagueId = "AL", City = "Minnesota"    , Nickname = "Twins"                                 },
            new TeamEntity { Code = "HOU", LeagueId = "AL", City = "Houston"      , Nickname = "Astros"                                },
            new TeamEntity { Code = "LAA", LeagueId = "AL", City = "Los Angeles"  , Nickname = "Angels"                                },
            new TeamEntity { Code = "OAK", LeagueId = "AL", City = "Oakland"      , Nickname = "Athletics"                             },
            new TeamEntity { Code = "SEA", LeagueId = "AL", City = "Seattle"      , Nickname = "Mariners"                              },
            new TeamEntity { Code = "TEX", LeagueId = "AL", City = "Texas"        , Nickname = "Rangers"                               },
            new TeamEntity { Code = "ATL", LeagueId = "NL", City = "Atlanta"      , Nickname = "Braves"                                },
            new TeamEntity { Code = "MIA", LeagueId = "NL", City = "Miami"        , Nickname = "Marlins"                               },
            new TeamEntity { Code = "NYM", LeagueId = "NL", City = "New York"     , Nickname = "Mets"                                  },
            new TeamEntity { Code = "PHI", LeagueId = "NL", City = "Philadelphia" , Nickname = "Phillies"                              },
            new TeamEntity { Code = "WAS", LeagueId = "NL", City = "Washington"   , Nickname = "Nationals"                             },
            new TeamEntity { Code = "CHC", LeagueId = "NL", City = "Chicago"      , Nickname = "Cubs"                                  },
            new TeamEntity { Code = "CIN", LeagueId = "NL", City = "Cincinnati"   , Nickname = "Reds"                                  },
            new TeamEntity { Code = "MIL", LeagueId = "NL", City = "Milwaukee"    , Nickname = "Brewers"                               },
            new TeamEntity { Code = "PIT", LeagueId = "NL", City = "Pittsburgh"   , Nickname = "Pirates"                               },
            new TeamEntity { Code = "STL", LeagueId = "NL", City = "St. Louis"    , Nickname = "Cardinals"                             },
            new TeamEntity { Code = "ARZ", LeagueId = "NL", City = "Arizona"      , Nickname = "Diamondbacks", AlternativeCode = "ARI" },
            new TeamEntity { Code = "COL", LeagueId = "NL", City = "Colorado"     , Nickname = "Rockies"                               },
            new TeamEntity { Code = "LAD", LeagueId = "NL", City = "Los Angeles"  , Nickname = "Dodgers"     , AlternativeCode = "LA"  },
            new TeamEntity { Code = "SD" , LeagueId = "NL", City = "San Diego"    , Nickname = "Padres"                                },
            new TeamEntity { Code = "SF" , LeagueId = "NL", City = "San Francisco", Nickname = "Giants"                                }
        };

        [Fact]
        public async void GetTeamsCacheTest()
        {
            var services = new ServiceCollection();
            services.AddLazyCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IAppCache>();
            var teamRepo = new Mock<ITeamRepository>();
            teamRepo.Setup(o => o.GetAllTeams()).Returns(Task.FromResult(TEAMS));
            var service = new GetTeamsService(memoryCache, teamRepo.Object);
            Assert.Equal(31, (await service.GetTeams()).Count);
            Assert.Equal(31, (await service.GetTeams()).Count);
            teamRepo.Verify(x => x.GetAllTeams(), Times.Once);
        }
    }
}
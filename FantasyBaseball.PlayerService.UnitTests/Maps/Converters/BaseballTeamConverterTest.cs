using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.Common.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.Maps.Converters.UnitTests
{
    public class BaseballTeamConverterTest
    {
        private static readonly List<BaseballTeam> TEAMS = new List<BaseballTeam>
        {
            new BaseballTeam { Code = ""   , LeagueId = ""  , City = "Free Agent"   , Nickname = "Free Agent"                            },
            new BaseballTeam { Code = "BAL", LeagueId = "AL", City = "Baltimore"    , Nickname = "Orioles"                               },
            new BaseballTeam { Code = "BOS", LeagueId = "AL", City = "Boston"       , Nickname = "Red Sox"                               },
            new BaseballTeam { Code = "NYY", LeagueId = "AL", City = "New York"     , Nickname = "Yankees"                               },
            new BaseballTeam { Code = "TB" , LeagueId = "AL", City = "Tampa Bay"    , Nickname = "Rays"       , AlternativeCode = "TAM"  },
            new BaseballTeam { Code = "TOR", LeagueId = "AL", City = "Toronto"      , Nickname = "Blue Jays"                             },
            new BaseballTeam { Code = "CWS", LeagueId = "AL", City = "Chicago"      , Nickname = "White Sox"  , AlternativeCode = "CHW"  },
            new BaseballTeam { Code = "CLE", LeagueId = "AL", City = "Cleveland"    , Nickname = "Indians"                               },
            new BaseballTeam { Code = "DET", LeagueId = "AL", City = "Detriot"      , Nickname = "Tigers"                                },
            new BaseballTeam { Code = "KC" , LeagueId = "AL", City = "Kansas City"  , Nickname = "Royals"                                },
            new BaseballTeam { Code = "MIN", LeagueId = "AL", City = "Minnesota"    , Nickname = "Twins"                                 },
            new BaseballTeam { Code = "HOU", LeagueId = "AL", City = "Houston"      , Nickname = "Astros"                                },
            new BaseballTeam { Code = "LAA", LeagueId = "AL", City = "Los Angeles"  , Nickname = "Angels"                                },
            new BaseballTeam { Code = "OAK", LeagueId = "AL", City = "Oakland"      , Nickname = "Athletics"                             },
            new BaseballTeam { Code = "SEA", LeagueId = "AL", City = "Seattle"      , Nickname = "Mariners"                              },
            new BaseballTeam { Code = "TEX", LeagueId = "AL", City = "Texas"        , Nickname = "Rangers"                               },
            new BaseballTeam { Code = "ATL", LeagueId = "NL", City = "Atlanta"      , Nickname = "Braves"                                },
            new BaseballTeam { Code = "MIA", LeagueId = "NL", City = "Miami"        , Nickname = "Marlins"                               },
            new BaseballTeam { Code = "NYM", LeagueId = "NL", City = "New York"     , Nickname = "Mets"                                  },
            new BaseballTeam { Code = "PHI", LeagueId = "NL", City = "Philadelphia" , Nickname = "Phillies"                              },
            new BaseballTeam { Code = "WAS", LeagueId = "NL", City = "Washington"   , Nickname = "Nationals"                             },
            new BaseballTeam { Code = "CHC", LeagueId = "NL", City = "Chicago"      , Nickname = "Cubs"                                  },
            new BaseballTeam { Code = "CIN", LeagueId = "NL", City = "Cincinnati"   , Nickname = "Reds"                                  },
            new BaseballTeam { Code = "MIL", LeagueId = "NL", City = "Milwaukee"    , Nickname = "Brewers"                               },
            new BaseballTeam { Code = "PIT", LeagueId = "NL", City = "Pittsburgh"   , Nickname = "Pirates"                               },
            new BaseballTeam { Code = "STL", LeagueId = "NL", City = "St. Louis"    , Nickname = "Cardinals"                             },
            new BaseballTeam { Code = "ARZ", LeagueId = "NL", City = "Arizona"      , Nickname = "Diamondbacks", AlternativeCode = "ARI" },
            new BaseballTeam { Code = "COL", LeagueId = "NL", City = "Colorado"     , Nickname = "Rockies"                               },
            new BaseballTeam { Code = "LAD", LeagueId = "NL", City = "Los Angeles"  , Nickname = "Dodgers"     , AlternativeCode = "LA"  },
            new BaseballTeam { Code = "SD" , LeagueId = "NL", City = "San Diego"    , Nickname = "Padres"                                },
            new BaseballTeam { Code = "SF" , LeagueId = "NL", City = "San Francisco", Nickname = "Giants"                                }
        };

        [Theory]
        [InlineData("MIL", "MIL")]
        [InlineData("mIl", "MIL")]
        [InlineData("", null)]
        [InlineData(null, null)]
        public void ConvertFromStringTest(string value, string expected) =>
            Assert.Equal(expected, BuildBaseballTeamString(new BaseballTeamConverter().ConvertFromString(value, null, null)));

        [Theory]
        [InlineData("MIL", "MIL")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void ConvertToStringTest(string value, string expected) =>
            Assert.Equal(expected, new BaseballTeamConverter().ConvertToString(BuildBaseballTeam(value), null, null));

        private string BuildBaseballTeamString(object team) => ((BaseballTeam)team).Code;

        private static BaseballTeam BuildBaseballTeam(string team) => TEAMS.FirstOrDefault(t => t.Code == team);
    }
}
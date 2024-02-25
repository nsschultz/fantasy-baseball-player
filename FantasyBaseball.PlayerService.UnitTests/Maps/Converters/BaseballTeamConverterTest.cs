using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.Maps.Converters.UnitTests
{
  public class BaseballTeamConverterTest
  {
    private static readonly List<BaseballTeam> TEAMS =
    [
      new() { Code = ""   , LeagueId = ""  , City = "Free Agent"   , Nickname = "Free Agent"                            },
      new() { Code = "BAL", LeagueId = "AL", City = "Baltimore"    , Nickname = "Orioles"                               },
      new() { Code = "BOS", LeagueId = "AL", City = "Boston"       , Nickname = "Red Sox"                               },
      new() { Code = "NYY", LeagueId = "AL", City = "New York"     , Nickname = "Yankees"                               },
      new() { Code = "TB" , LeagueId = "AL", City = "Tampa Bay"    , Nickname = "Rays"       , AlternativeCode = "TAM"  },
      new() { Code = "TOR", LeagueId = "AL", City = "Toronto"      , Nickname = "Blue Jays"                             },
      new() { Code = "CWS", LeagueId = "AL", City = "Chicago"      , Nickname = "White Sox"  , AlternativeCode = "CHW"  },
      new() { Code = "CLE", LeagueId = "AL", City = "Cleveland"    , Nickname = "Indians"                               },
      new() { Code = "DET", LeagueId = "AL", City = "Detriot"      , Nickname = "Tigers"                                },
      new() { Code = "KC" , LeagueId = "AL", City = "Kansas City"  , Nickname = "Royals"                                },
      new() { Code = "MIN", LeagueId = "AL", City = "Minnesota"    , Nickname = "Twins"                                 },
      new() { Code = "HOU", LeagueId = "AL", City = "Houston"      , Nickname = "Astros"                                },
      new() { Code = "LAA", LeagueId = "AL", City = "Los Angeles"  , Nickname = "Angels"                                },
      new() { Code = "OAK", LeagueId = "AL", City = "Oakland"      , Nickname = "Athletics"                             },
      new() { Code = "SEA", LeagueId = "AL", City = "Seattle"      , Nickname = "Mariners"                              },
      new() { Code = "TEX", LeagueId = "AL", City = "Texas"        , Nickname = "Rangers"                               },
      new() { Code = "ATL", LeagueId = "NL", City = "Atlanta"      , Nickname = "Braves"                                },
      new() { Code = "MIA", LeagueId = "NL", City = "Miami"        , Nickname = "Marlins"                               },
      new() { Code = "NYM", LeagueId = "NL", City = "New York"     , Nickname = "Mets"                                  },
      new() { Code = "PHI", LeagueId = "NL", City = "Philadelphia" , Nickname = "Phillies"                              },
      new() { Code = "WAS", LeagueId = "NL", City = "Washington"   , Nickname = "Nationals"                             },
      new() { Code = "CHC", LeagueId = "NL", City = "Chicago"      , Nickname = "Cubs"                                  },
      new() { Code = "CIN", LeagueId = "NL", City = "Cincinnati"   , Nickname = "Reds"                                  },
      new() { Code = "MIL", LeagueId = "NL", City = "Milwaukee"    , Nickname = "Brewers"                               },
      new() { Code = "PIT", LeagueId = "NL", City = "Pittsburgh"   , Nickname = "Pirates"                               },
      new() { Code = "STL", LeagueId = "NL", City = "St. Louis"    , Nickname = "Cardinals"                             },
      new() { Code = "ARZ", LeagueId = "NL", City = "Arizona"      , Nickname = "Diamondbacks", AlternativeCode = "ARI" },
      new() { Code = "COL", LeagueId = "NL", City = "Colorado"     , Nickname = "Rockies"                               },
      new() { Code = "LAD", LeagueId = "NL", City = "Los Angeles"  , Nickname = "Dodgers"     , AlternativeCode = "LA"  },
      new() { Code = "SD" , LeagueId = "NL", City = "San Diego"    , Nickname = "Padres"                                },
      new() { Code = "SF" , LeagueId = "NL", City = "San Francisco", Nickname = "Giants"                                }
    ];

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

    private static string BuildBaseballTeamString(object team) => ((BaseballTeam)team).Code;

    private static BaseballTeam BuildBaseballTeam(string team) => TEAMS.FirstOrDefault(t => t.Code == team);
  }
}
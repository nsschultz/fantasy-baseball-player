using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Maps.Converters.UnitTests
{
    public class PositionListConverterTest
    {
        private static readonly List<BaseballPosition> POSITIONS = new List<BaseballPosition>
        {
            new BaseballPosition { Code = ""    , FullName = "Unknown"          , PlayerType = PlayerType.U, SortOrder = int.MaxValue },
            new BaseballPosition { Code = "C"   , FullName = "Catcher"          , PlayerType = PlayerType.B, SortOrder = 0            },
            new BaseballPosition { Code = "1B"  , FullName = "First Baseman"    , PlayerType = PlayerType.B, SortOrder = 1            },
            new BaseballPosition { Code = "2B"  , FullName = "Second Baseman"   , PlayerType = PlayerType.B, SortOrder = 2            },
            new BaseballPosition { Code = "3B"  , FullName = "Third Baseman"    , PlayerType = PlayerType.B, SortOrder = 3            },
            new BaseballPosition { Code = "SS"  , FullName = "Shortstop"        , PlayerType = PlayerType.B, SortOrder = 4            },
            new BaseballPosition { Code = "CIF" , FullName = "Corner Infielder" , PlayerType = PlayerType.B, SortOrder = 5            },
            new BaseballPosition { Code = "MIF" , FullName = "Middle Infielder" , PlayerType = PlayerType.B, SortOrder = 6            },
            new BaseballPosition { Code = "IF"  , FullName = "Infielder"        , PlayerType = PlayerType.B, SortOrder = 7            },
            new BaseballPosition { Code = "LF"  , FullName = "Left Fielder"     , PlayerType = PlayerType.B, SortOrder = 8            },
            new BaseballPosition { Code = "CF"  , FullName = "Center Feilder"   , PlayerType = PlayerType.B, SortOrder = 9            },
            new BaseballPosition { Code = "RF"  , FullName = "Right Fielder"    , PlayerType = PlayerType.B, SortOrder = 10           },
            new BaseballPosition { Code = "OF"  , FullName = "Outfielder"       , PlayerType = PlayerType.B, SortOrder = 11           },
            new BaseballPosition { Code = "DH"  , FullName = "Designated Hitter", PlayerType = PlayerType.B, SortOrder = 12           },
            new BaseballPosition { Code = "UTIL", FullName = "Utility"          , PlayerType = PlayerType.B, SortOrder = 13           },
            new BaseballPosition { Code = "SP"  , FullName = "Starting Pitcher" , PlayerType = PlayerType.P, SortOrder = 100          },
            new BaseballPosition { Code = "RP"  , FullName = "Relief Pitcher"   , PlayerType = PlayerType.P, SortOrder = 101          },
            new BaseballPosition { Code = "P"   , FullName = "Pitcher"          , PlayerType = PlayerType.P, SortOrder = 102          }
        };

        [Theory]
        [InlineData("ss-of", "SS-OF")]
        [InlineData(" P ", "P")]
        [InlineData("", "")]
        [InlineData("-", "-")]
        public void ConvertFromStringTest(string value, string expected) =>
            Assert.Equal(expected, BuildPositionString(new PositionListConverter().ConvertFromString(value, null, null)));

        [Theory]
        [InlineData("SS-OF-1B-C", "C-1B-SS-OF")]
        [InlineData("P", "P")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void ConvertToStringTest(string value, string expected) =>
            Assert.Equal(expected, new PositionListConverter().ConvertToString(BuildPositionList(value), null, null));

        private string BuildPositionString(object positions) => string.Join("-", ((List<BaseballPosition>)positions).Select(p => p.Code));

        private static List<BaseballPosition> BuildPositionList(string positions)
        {
            if (positions == null) return null;
            return positions.Split("-").SelectMany(p => POSITIONS.Where(pp => pp.Code == p)).ToList();
        }
    }
}
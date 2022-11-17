using System;
using FantasyBaseball.Common.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Entities.UnitTests
{
    public class PlayerLeagueStatusEntityTest
    {
        [Fact]
        public void DefaultsSetTest()
        {
            var obj = new PlayerLeagueStatusEntity();
            Assert.Equal((Guid)default, obj.PlayerId);
            Assert.Equal(0, obj.LeagueId);
            Assert.Equal(LeagueStatus.A, obj.LeagueStatus);
            Assert.Null(obj.Player);
        }
    }
}
using System;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.PlayerService.Database.Entities;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Entities;

public class PlayerLeagueStatusEntityTest
{
    [Fact]
    public void DefaultsSetTest()
    {
        var obj = new PlayerLeagueStatusEntity();
        Assert.Equal(Guid.Empty, obj.PlayerId);
        Assert.Equal(0, obj.LeagueId);
        Assert.Equal(LeagueStatus.A, obj.LeagueStatus);
        Assert.Null(obj.Player);
    }
}
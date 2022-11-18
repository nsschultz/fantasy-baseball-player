using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class ClearPlayerServiceTest : IDisposable
    {
        private PlayerContext _context;

        public ClearPlayerServiceTest() => _context = CreateContext().Result;

        [Fact]
        public async void ClearAllPlayersTestValid()
        {
            await new ClearPlayerService(_context).ClearAllPlayers();
            Assert.Equal(0, _context.Players.Count());
            Assert.Equal(0, _context.LeagueStatuses.Count());
            Assert.Equal(0, _context.BattingStats.Count());
            Assert.Equal(0, _context.PitchingStats.Count());
            Assert.Equal(31, _context.Teams.Count());
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private async Task<PlayerContext> CreateContext()
        {
            var options = new DbContextOptionsBuilder<PlayerContext>()
                .UseInMemoryDatabase(databaseName: "ClearPlayerServiceTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new PlayerContext(options);
            context.Database.EnsureCreated();
            Assert.Equal(31, await context.Teams.CountAsync());
            await context.AddRangeAsync(
                new PlayerEntity
                {
                    BhqId = 1,
                    Type = PlayerType.B,
                    Team = "MIL",
                    BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.UNKN, AtBats = 1 } },
                    LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 1, LeagueStatus = LeagueStatus.R } }
                },
                new PlayerEntity
                {
                    BhqId = 2,
                    Type = PlayerType.P,
                    Team = "MIL",
                    PitchingStats = new List<PitchingStatsEntity> { new PitchingStatsEntity { StatsType = StatsType.UNKN, InningsPitched = 2 } },
                    LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 2, LeagueStatus = LeagueStatus.R } }
                },
                new PlayerEntity
                {
                    BhqId = 3,
                    Type = PlayerType.B,
                    Team = "TB",
                    BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.UNKN, AtBats = 3 } },
                    LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 3, LeagueStatus = LeagueStatus.R } }
                },
                new PlayerEntity
                {
                    BhqId = 5,
                    Type = PlayerType.B,
                    Team = "MIL",
                    BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.UNKN, AtBats = 5 } },
                    LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 5, LeagueStatus = LeagueStatus.R } }
                }
            );
            await context.SaveChangesAsync();
            Assert.Equal(4, await context.Players.CountAsync());
            return context;
        }
    }
}
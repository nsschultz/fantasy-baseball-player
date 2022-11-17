using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace FantasyBaseball.PlayerService.Database
{
    /// <summary>The context object for players and their related entities.</summary>
    public class PlayerContext : DbContext, IPlayerContext
    {
        private IDbContextTransaction _transaction;

        /// <summary>
        ///     Initializes a new instance of the Microsoft.EntityFrameworkCore.DbContext class using the specified options. 
        ///     The Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
        ///     method will still be called to allow further configuration of the options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) { }

        /// <summary>A collection of batting stats.</summary>
        public DbSet<BattingStatsEntity> BattingStats { get; set; }

        /// <summary>A collection of league statuses.</summary>
        public DbSet<PlayerLeagueStatusEntity> LeagueStatuses { get; set; }

        /// <summary>A collection of  teams.</summary>
        public DbSet<TeamEntity> Teams { get; set; }

        /// <summary>A collection of pitching stats.</summary>
        public DbSet<PitchingStatsEntity> PitchingStats { get; set; }

        /// <summary>A collection of players.</summary>
        public DbSet<PlayerEntity> Players { get; set; }

        /// <summary>Starts a new database transaction.</summary>
        public async Task BeginTransaction() => _transaction = await Database.BeginTransactionAsync();

        /// <summary>Commits the database transaction.</summary>
        public async Task Commit()
        {
            try { await SaveAndCommit(); }
            finally { await _transaction.DisposeAsync(); }
        }

        /// <summary>Rolls the database transaction back.</summary>
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildPlayerModel(modelBuilder.Entity<PlayerEntity>());
            BuildPlayerLeagueStatusModel(modelBuilder.Entity<PlayerLeagueStatusEntity>());
            BuildBattingStatsModel(modelBuilder.Entity<BattingStatsEntity>());
            BuildPitchingStatsModel(modelBuilder.Entity<PitchingStatsEntity>());
            BuildTeamModel(modelBuilder.Entity<TeamEntity>());
            BuildPlayerPositionModel(modelBuilder.Entity<PlayerPositionEntity>());
        }

        private static void BuildBattingStatsModel(EntityTypeBuilder<BattingStatsEntity> builder)
        {
            builder.HasKey(bs => new { bs.PlayerId, bs.StatsType }).HasName("BattingStats_PK");
            builder.HasOne(bs => bs.Player)
                .WithMany(p => p.BattingStats)
                .HasForeignKey(bs => bs.PlayerId)
                .HasConstraintName("BattingStats_Player_FK");
        }

        private static void BuildTeamModel(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(mt => mt.Code).HasName("Team_PK");
            builder.Property(mt => mt.Code).HasMaxLength(3);
            builder.Property(mt => mt.AlternativeCode).HasMaxLength(3);
            builder.Property(mt => mt.LeagueId).HasMaxLength(2);
            builder.Property(mt => mt.City).HasMaxLength(20);
            builder.Property(mt => mt.Nickname).HasMaxLength(20);
            builder.HasData(
                new TeamEntity { Code = "", LeagueId = "", City = "Free Agent", Nickname = "Free Agent" },
                new TeamEntity { Code = "BAL", LeagueId = "AL", City = "Baltimore", Nickname = "Orioles" },
                new TeamEntity { Code = "BOS", LeagueId = "AL", City = "Boston", Nickname = "Red Sox" },
                new TeamEntity { Code = "NYY", LeagueId = "AL", City = "New York", Nickname = "Yankees" },
                new TeamEntity { Code = "TB", LeagueId = "AL", City = "Tampa Bay", Nickname = "Rays", AlternativeCode = "TAM" },
                new TeamEntity { Code = "TOR", LeagueId = "AL", City = "Toronto", Nickname = "Blue Jays" },
                new TeamEntity { Code = "CWS", LeagueId = "AL", City = "Chicago", Nickname = "White Sox", AlternativeCode = "CHW" },
                new TeamEntity { Code = "CLE", LeagueId = "AL", City = "Cleveland", Nickname = "Guardians" },
                new TeamEntity { Code = "DET", LeagueId = "AL", City = "Detriot", Nickname = "Tigers" },
                new TeamEntity { Code = "KC", LeagueId = "AL", City = "Kansas City", Nickname = "Royals" },
                new TeamEntity { Code = "MIN", LeagueId = "AL", City = "Minnesota", Nickname = "Twins" },
                new TeamEntity { Code = "HOU", LeagueId = "AL", City = "Houston", Nickname = "Astros" },
                new TeamEntity { Code = "LAA", LeagueId = "AL", City = "Los Angeles", Nickname = "Angels" },
                new TeamEntity { Code = "OAK", LeagueId = "AL", City = "Oakland", Nickname = "Athletics" },
                new TeamEntity { Code = "SEA", LeagueId = "AL", City = "Seattle", Nickname = "Mariners" },
                new TeamEntity { Code = "TEX", LeagueId = "AL", City = "Texas", Nickname = "Rangers" },
                new TeamEntity { Code = "ATL", LeagueId = "NL", City = "Atlanta", Nickname = "Braves" },
                new TeamEntity { Code = "MIA", LeagueId = "NL", City = "Miami", Nickname = "Marlins" },
                new TeamEntity { Code = "NYM", LeagueId = "NL", City = "New York", Nickname = "Mets" },
                new TeamEntity { Code = "PHI", LeagueId = "NL", City = "Philadelphia", Nickname = "Phillies" },
                new TeamEntity { Code = "WAS", LeagueId = "NL", City = "Washington", Nickname = "Nationals" },
                new TeamEntity { Code = "CHC", LeagueId = "NL", City = "Chicago", Nickname = "Cubs" },
                new TeamEntity { Code = "CIN", LeagueId = "NL", City = "Cincinnati", Nickname = "Reds" },
                new TeamEntity { Code = "MIL", LeagueId = "NL", City = "Milwaukee", Nickname = "Brewers" },
                new TeamEntity { Code = "PIT", LeagueId = "NL", City = "Pittsburgh", Nickname = "Pirates" },
                new TeamEntity { Code = "STL", LeagueId = "NL", City = "St. Louis", Nickname = "Cardinals" },
                new TeamEntity { Code = "ARZ", LeagueId = "NL", City = "Arizona", Nickname = "Diamondbacks", AlternativeCode = "ARI" },
                new TeamEntity { Code = "COL", LeagueId = "NL", City = "Colorado", Nickname = "Rockies" },
                new TeamEntity { Code = "LAD", LeagueId = "NL", City = "Los Angeles", Nickname = "Dodgers", AlternativeCode = "LA" },
                new TeamEntity { Code = "SD", LeagueId = "NL", City = "San Diego", Nickname = "Padres" },
                new TeamEntity { Code = "SF", LeagueId = "NL", City = "San Francisco", Nickname = "Giants" }
            );
        }

        private static void BuildPitchingStatsModel(EntityTypeBuilder<PitchingStatsEntity> builder)
        {
            builder.HasKey(ps => new { ps.PlayerId, ps.StatsType }).HasName("PitchingStats_PK");
            builder.HasOne(ps => ps.Player)
                .WithMany(p => p.PitchingStats)
                .HasForeignKey(ps => ps.PlayerId)
                .HasConstraintName("PitchingStats_Player_FK");
        }

        private static void BuildPlayerLeagueStatusModel(EntityTypeBuilder<PlayerLeagueStatusEntity> builder)
        {
            builder.HasKey(pls => new { pls.PlayerId, pls.LeagueId }).HasName("LeagueStatus_PK");
            builder.HasOne(pls => pls.Player)
                .WithMany(p => p.LeagueStatuses)
                .HasForeignKey(pls => pls.PlayerId)
                .HasConstraintName("LeagueStatus_Player_FK");
        }

        private static void BuildPlayerModel(EntityTypeBuilder<PlayerEntity> builder)
        {
            builder.HasKey(p => p.Id).HasName("Player_PK");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(20);
            builder.Property(p => p.LastName).HasMaxLength(20);
            builder.HasAlternateKey(p => new { p.BhqId, p.Type }).HasName("Player_Bhq_AK");
            builder.HasOne(p => p.PlayerTeam)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.Team)
                .HasConstraintName("Player_Team_FK");
        }

        private static void BuildPlayerPositionModel(EntityTypeBuilder<PlayerPositionEntity> builder)
        {
            builder.HasKey(pp => new { pp.PlayerId, pp.PositionCode });
            builder.Property(pp => pp.PositionCode).HasMaxLength(3);
            builder.HasOne(pp => pp.Player)
                .WithMany(p => p.Positions)
                .HasForeignKey(pp => pp.PlayerId)
                .HasConstraintName("PlayerPosition_Player_FK");
        }

        private async Task SaveAndCommit()
        {
            await SaveChangesAsync();
            await _transaction.CommitAsync();
        }
    }
}
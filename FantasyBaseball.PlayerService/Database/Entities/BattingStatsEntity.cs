using System;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Entities
{
    /// <summary>A single type of batting stats for a player.</summary>
    public class BattingStatsEntity
    {
        /// <summary>At Bats (AB)</summary>
        public int AtBats { get; set; }

        /// <summary>Base on Balls (BB)</summary>
        public int BaseOnBalls { get; set; }

        /// <summary>Caught Stealing (CS)</summary>
        public int CaughtStealing { get; set; }

        /// <summary>Doubles (2B)</summary>
        public int Doubles { get; set; }

        /// <summary>Hits (H)</summary>
        public int Hits { get; set; }

        /// <summary>Home Runs (HR)</summary>
        public int HomeRuns { get; set; }

        /// <summary>The player's ID.</summary>
        public Guid PlayerId { get; set; }

        /// <summary>Linear Weighted Power Index (PX)</summary>
        public double Power { get; set; }

        /// <summary>Runs (R)</summary>
        public int Runs { get; set; }

        /// <summary>Runs Batted In (RBI)</summary>
        public int RunsBattedIn { get; set; }

        /// <summary>Statistically Scouted Speed (SPD)</summary>
        public double Speed { get; set; }

        /// <summary>The type of stats. Year to Date (YTD) or Projected (PROJ). </summary>
        public StatsType StatsType { get; set; }

        /// <summary>Strike Outs (K)</summary>
        public int StrikeOuts { get; set; }

        /// <summary>Stolen Bases (SB)</summary>
        public int StolenBases { get; set; }

        /// <summary>Triples (3B)</summary>
        public int Triples { get; set; }

        /// <summary>All of the information that makes up a baseball player.</summary>
        public PlayerEntity Player { get; set; }
    }
}
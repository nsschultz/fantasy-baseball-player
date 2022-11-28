using System.Linq;
using System.Text.Json.Serialization;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Models
{
    /// <summary>A marker object for breaking up the mappers.</summary>
    public class CsvBaseballPlayer : BaseballPlayerV2
    {
        /// <summary>Pitching Stats (Projected) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public BattingStats CombinedBattingStats
        {
            get { return GetBattingStats(StatsType.CMBD); }
            set { AddBattingStats(value, StatsType.CMBD); }
        }

        /// <summary>Batting Stats (Projected) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public BattingStats ProjectedBattingStats
        {
            get { return GetBattingStats(StatsType.PROJ); }
            set { AddBattingStats(value, StatsType.PROJ); }
        }

        /// <summary>Batting Stats (Year to Date) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public BattingStats YearToDateBattingStats
        {
            get { return GetBattingStats(StatsType.YTD); }
            set { AddBattingStats(value, StatsType.YTD); }
        }

        /// <summary>Pitching Stats (Projected) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public PitchingStats CombinedPitchingStats
        {
            get { return GetPitchingStats(StatsType.CMBD); }
            set { AddPitchingStats(value, StatsType.CMBD); }
        }

        /// <summary>Pitching Stats (Projected) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public PitchingStats ProjectedPitchingStats
        {
            get { return GetPitchingStats(StatsType.PROJ); }
            set { AddPitchingStats(value, StatsType.PROJ); }
        }

        /// <summary>Pitching Stats (Year to Date) for a given player.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public PitchingStats YearToDatePitchingStats
        {
            get { return GetPitchingStats(StatsType.YTD); }
            set { AddPitchingStats(value, StatsType.YTD); }
        }

        private void AddBattingStats(BattingStats value, StatsType statsType)
        {
            if (value == null) return;
            value.StatsType = statsType;
            var existing = GetBattingStats(statsType);
            if (existing != null) BattingStats.Remove(existing);
            BattingStats.Add(value);
        }

        private void AddPitchingStats(PitchingStats value, StatsType statsType)
        {
            if (value == null) return;
            value.StatsType = statsType;
            var existing = GetPitchingStats(statsType);
            if (existing != null) PitchingStats.Remove(existing);
            PitchingStats.Add(value);
        }

        private BattingStats GetBattingStats(StatsType statsType)
        {
            if (!BattingStats.Any(s => s.StatsType == statsType)) BattingStats.Add(new BattingStats { StatsType = statsType });
            return BattingStats.FirstOrDefault(s => s.StatsType == statsType);
        }

        private PitchingStats GetPitchingStats(StatsType statsType)
        {
            if (!PitchingStats.Any(s => s.StatsType == statsType)) PitchingStats.Add(new PitchingStats { StatsType = statsType });
            return PitchingStats.FirstOrDefault(s => s.StatsType == statsType);
        }
    }
}
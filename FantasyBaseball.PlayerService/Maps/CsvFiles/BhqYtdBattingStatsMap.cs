using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's year to date batting file.</summary>
  public class BhqYtdBattingsStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqYtdBattingsStatsMap()
    {
      // Constants
      Map(m => m.Type).Constant(PlayerType.B);
      Map(m => m.Status).Constant(PlayerStatus.NE);
      // Skipped player fields: Bats,Pos,LG
      Map(m => m.BhqId).Name("HQID");
      Map(m => m.MlbAmId).Name("MLBAMID");
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age");
      Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
      Map(m => m.AverageDraftPick).Name("ADP");
      Map(m => m.AverageDraftPickMin).Name("Min ADP");
      Map(m => m.AverageDraftPickMax).Name("Max ADP");
      // Skipped stat fields:	PA,OBP,SLG,OPS,BB%,Ct%,Eye,H%,HctX,xBA,GB %,LD %,FB %,xPX,SPD,RCG,RAR,BPV,C,1B,2B,3B,SS,OF,DH
      // TODO: Need to calculate AB
      Map(m => m.ProjectedBattingStats.Runs).Name("R");
      Map(m => m.ProjectedBattingStats.Hits).Name("H");
      Map(m => m.ProjectedBattingStats.Doubles).Name("2B");
      Map(m => m.ProjectedBattingStats.Triples).Name("3B");
      Map(m => m.ProjectedBattingStats.HomeRuns).Name("HR");
      Map(m => m.ProjectedBattingStats.RunsBattedIn).Name("RBI");
      Map(m => m.ProjectedBattingStats.BaseOnBalls).Name("BB");
      Map(m => m.ProjectedBattingStats.StrikeOuts).Name("K");
      Map(m => m.ProjectedBattingStats.StolenBases).Name("SB");
      Map(m => m.ProjectedBattingStats.CaughtStealing).Name("CS");
      Map(m => m.ProjectedBattingStats.BattingAverage).Name("AVG");
      Map(m => m.ProjectedBattingStats.ContractRate).Name("Ct%").TypeConverter<RateConverter>(); ;
      Map(m => m.ProjectedBattingStats.Power).Name("PX");
      Map(m => m.ProjectedBattingStats.Speed).Name("RSPD");
    }
  }
}
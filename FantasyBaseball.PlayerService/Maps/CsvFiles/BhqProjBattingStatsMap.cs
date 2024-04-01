using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's projected batting file.</summary>
  public class BhqProjectedBattingsStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqProjectedBattingsStatsMap()
    {
      // Constants
      Map(m => m.Type).Constant(PlayerType.B);
      Map(m => m.Status).Constant(PlayerStatus.NE);
      // Skipped player fields: Bats,Lg,Pos,LY5,LY10,LY15,LY20,LIMA,DL,12$,15$
      Map(m => m.BhqId).Name("HQID");
      Map(m => m.MlbAmId).Name("MLBAMID");
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age");
      Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
      Map(m => m.Reliability).Name("MM Code").TypeConverter<ReliabilityConverter>();
      Map(m => m.MayberryMethod).Name("MM");
      Map(m => m.AverageDraftPick).Name("ADP");
      Map(m => m.AverageDraftPickMin).Name("Min ADP");
      Map(m => m.AverageDraftPickMax).Name("Max ADP");
      // Skipped stat fields:	PA,AVG,OBP,SLG,OPS,BB%,ct%,Eye,h%,SPD,G%,L%,F%,xBA,BA,RC/G,RAR,BPX
      Map(m => m.ProjectedBattingStats.AtBats).Name("AB");
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
      Map(m => m.ProjectedBattingStats.Power).Name("PX");
      Map(m => m.ProjectedBattingStats.Speed).Name("RSpd");
    }
  }
}
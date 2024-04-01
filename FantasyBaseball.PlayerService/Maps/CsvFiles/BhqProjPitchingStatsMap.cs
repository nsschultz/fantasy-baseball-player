using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's projected pitching file.</summary>
  public class BhqProjectedPitchingStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqProjectedPitchingStatsMap()
    {
      // Constants
      Map(m => m.Type).Constant(PlayerType.P);
      Map(m => m.Status).Constant(PlayerStatus.NE);
      // Skipped player fields: Throws,LG,LIMA,DL,12$,15$
      Map(m => m.BhqId).Name("HQID");
      Map(m => m.MlbAmId).Name("MLBAMID");
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age");
      Map(m => m.Team).Name("Tm").TypeConverter<BaseballTeamConverter>();
      Map(m => m.Reliability).Name("MM Code").TypeConverter<ReliabilityConverter>();
      Map(m => m.MayberryMethod).Name("MM");
      Map(m => m.AverageDraftPick).Name("ADP");
      Map(m => m.AverageDraftPickMin).Name("Min ADP");
      Map(m => m.AverageDraftPickMax).Name("Max ADP");
      // Skipped stat fields:	G,ERA,WHIP,BF/G,K9,K%,BB/9,BB%,Cmd,K-BB%,HR9,OOB,xERA,L%,H%,S%,RAR,BPX
      Map(m => m.ProjectedPitchingStats.Wins).Name("W");
      Map(m => m.ProjectedPitchingStats.Losses).Name("L");
      Map(m => m.ProjectedPitchingStats.QualityStarts).Name("QS");
      Map(m => m.ProjectedPitchingStats.Saves).Name("SV");
      Map(m => m.ProjectedPitchingStats.BlownSaves).Name("BS");
      Map(m => m.ProjectedPitchingStats.Holds).Name("HD");
      Map(m => m.ProjectedPitchingStats.InningsPitched).Name("IP");
      Map(m => m.ProjectedPitchingStats.HitsAllowed).Name("H");
      Map(m => m.ProjectedPitchingStats.EarnedRuns).Name("ER");
      Map(m => m.ProjectedPitchingStats.HomeRunsAllowed).Name("HR");
      Map(m => m.ProjectedPitchingStats.BaseOnBallsAllowed).Name("BB");
      Map(m => m.ProjectedPitchingStats.StrikeOuts).Name("K");
      Map(m => m.ProjectedPitchingStats.FlyBallRate).Name("F%").TypeConverter<RateConverter>();
      Map(m => m.ProjectedPitchingStats.GroundBallRate).Name("G%").TypeConverter<RateConverter>();
    }
  }
}
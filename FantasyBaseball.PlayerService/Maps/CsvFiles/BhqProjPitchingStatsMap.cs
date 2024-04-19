using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's projected pitching file.</summary>
  public class BhqProjPitchingStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqProjPitchingStatsMap()
    {
      // Constants
      Map(m => m.Type).Constant(PlayerType.P);
      Map(m => m.Status).Constant(PlayerStatus.NE);
      // Skipped player fields: Throws,LG,LIMA,DL,12$,15$
      Map(m => m.MlbAmId).Name("MLBAMID").TypeConverter<DefaultIntConverter>();
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age").TypeConverter<DefaultIntConverter>();
      Map(m => m.Team).Name("Tm").TypeConverter<BaseballTeamConverter>();
      Map(m => m.Reliability).Name("MM Code").TypeConverter<ReliabilityConverter>();
      Map(m => m.MayberryMethod).Name("MM").TypeConverter<DefaultIntConverter>();
      Map(m => m.AverageDraftPick).Name("ADP").TypeConverter<DefaultDoubleConverter>();
      Map(m => m.AverageDraftPickMin).Name("Min ADP").TypeConverter<DefaultIntConverter>();
      Map(m => m.AverageDraftPickMax).Name("Max ADP").TypeConverter<DefaultIntConverter>();
      // Skipped stat fields:	G,ERA,WHIP,BF/G,K9,K%,BB/9,BB%,Cmd,K-BB%,HR9,OOB,xERA,L%,H%,S%,RAR,BPX
      Map(m => m.ProjectedPitchingStats.Wins).Name("W").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.Losses).Name("L").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.QualityStarts).Name("QS").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.Saves).Name("SV").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.BlownSaves).Name("BS").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.Holds).Name("HD").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.InningsPitched).Name("IP").TypeConverter<DefaultDoubleConverter>();
      Map(m => m.ProjectedPitchingStats.HitsAllowed).Name("H").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.EarnedRuns).Name("ER").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.HomeRunsAllowed).Name("HR").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.BaseOnBallsAllowed).Name("BB").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.StrikeOuts).Name("K").TypeConverter<DefaultIntConverter>();
      Map(m => m.ProjectedPitchingStats.FlyBallRate).Name("F%").TypeConverter<RateConverter>();
      Map(m => m.ProjectedPitchingStats.GroundBallRate).Name("G%").TypeConverter<RateConverter>();
    }
  }
}
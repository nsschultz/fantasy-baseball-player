using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for BHQ's projected pitching file.</summary>
public class BhqProjPitchingStatsMap : ProjStatsMapping
{
  /// <summary>Creates a new instance of the mapper.</summary>
  public BhqProjPitchingStatsMap() => CreateMap();

  private void CreateMap()
  {
    MapSharedFields(PlayerType.P);
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
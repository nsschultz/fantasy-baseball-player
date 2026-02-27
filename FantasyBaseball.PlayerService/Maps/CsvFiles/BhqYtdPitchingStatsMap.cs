using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for BHQ's year to date pitching file.</summary>
public class BhqYtdPitchingStatsMap : YtdStatsMapping
{
  /// <summary>Creates a new instance of the mapper.</summary>
  public BhqYtdPitchingStatsMap() => CreateMap();

  private void CreateMap()
  {
    MapSharedFields(PlayerType.P);
    // Skipped stat fields:	G,GS,SV%,ERA,xERA,WHIP,BF/G,Vel,BB%,K/9,K%,SwK%,K-BB%,H%,S%,LD %,HR/9,HR/FB,xHR/FB,OBA,RAR,REff%,LI,BPX,Dom%,Dis%,R$,5x5$
    Map(m => m.YearToDatePitchingStats.InningsPitched).Name("IP").TypeConverter<DefaultDoubleConverter>();
    Map(m => m.YearToDatePitchingStats.QualityStarts).Name("QS").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.Wins).Name("W").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.Losses).Name("L").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.Saves).Name("SV").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.Holds).Name("HD").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.BlownSaves).Name("BS").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.HitsAllowed).Name("H").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.EarnedRuns).Name("ER").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.HomeRunsAllowed).Name("HR").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.StrikeOuts).Name("K").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.BaseOnBallsAllowed).Name("BB").TypeConverter<DefaultIntConverter>();
    Map(m => m.YearToDatePitchingStats.GroundBallRate).Name("GB%").TypeConverter<RateConverter>();
    Map(m => m.YearToDatePitchingStats.FlyBallRate).Name("FB %").TypeConverter<RateConverter>();
  }
}
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's year to date pitching file.</summary>
  public class BhqYtdPitchingStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqYtdPitchingStatsMap()
    {
      //
      // Constants
      Map(m => m.Type).Constant(PlayerType.P);
      Map(m => m.Status).Constant(PlayerStatus.NE);
      // Other Constants for missing fields
      Map(m => m.AverageDraftPick).Constant(-1);
      Map(m => m.AverageDraftPickMax).Constant(-1);
      Map(m => m.AverageDraftPickMin).Constant(-1);
      Map(m => m.MayberryMethod).Constant(-1);
      Map(m => m.Reliability).Constant(-1);
      // Skipped player fields: Throws,LG
      Map(m => m.MlbAmId).Name("MLBAMID").TypeConverter<DefaultIntConverter>();
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age").TypeConverter<DefaultIntConverter>();
      Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
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
}
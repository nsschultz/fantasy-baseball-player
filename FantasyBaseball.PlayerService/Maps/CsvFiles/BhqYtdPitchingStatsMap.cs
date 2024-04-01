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
      // Skipped player fields: Throws,LG
      Map(m => m.BhqId).Name("HQID");
      Map(m => m.MlbAmId).Name("MLBAMID");
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age");
      Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
      Map(m => m.AverageDraftPick).Name("ADP");
      Map(m => m.AverageDraftPickMin).Name("Min ADP");
      Map(m => m.AverageDraftPickMax).Name("Max ADP");
      // Skipped stat fields:	G,GS,SV%,ERA,xERA,WHIP,BF/G,Vel,BB%,K/9,K%,SwK%,K-BB%,H%,S%,LD %,HR/9,HR/FB,xHR/FB,OBA,RAR,REff%,LI,BPX,Dom%,Dis%,R$,5x5$
      Map(m => m.YearToDatePitchingStats.InningsPitched).Name("IP");
      Map(m => m.YearToDatePitchingStats.QualityStarts).Name("QS");
      Map(m => m.YearToDatePitchingStats.Wins).Name("W");
      Map(m => m.YearToDatePitchingStats.Losses).Name("L");
      Map(m => m.YearToDatePitchingStats.Saves).Name("SV");
      Map(m => m.YearToDatePitchingStats.Holds).Name("HD");
      Map(m => m.YearToDatePitchingStats.BlownSaves).Name("BS");
      Map(m => m.YearToDatePitchingStats.HitsAllowed).Name("H");
      Map(m => m.YearToDatePitchingStats.EarnedRuns).Name("ER");
      Map(m => m.YearToDatePitchingStats.HomeRunsAllowed).Name("HR");
      Map(m => m.YearToDatePitchingStats.StrikeOuts).Name("K");
      Map(m => m.YearToDatePitchingStats.BaseOnBallsAllowed).Name("BB");
      Map(m => m.YearToDatePitchingStats.GroundBallRate).Name("GB %").TypeConverter<RateConverter>();
      Map(m => m.YearToDatePitchingStats.FlyBallRate).Name("FB %").TypeConverter<RateConverter>();
    }
  }
}
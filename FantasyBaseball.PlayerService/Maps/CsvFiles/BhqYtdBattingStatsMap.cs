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
      // Other Constants for missing fields
      Map(m => m.AverageDraftPick).Constant(-1);
      Map(m => m.AverageDraftPickMax).Constant(-1);
      Map(m => m.AverageDraftPickMin).Constant(-1);
      Map(m => m.MayberryMethod).Constant(-1);
      Map(m => m.Reliability).Constant(-1);
      // Skipped player fields: Bats,Pos,LG
      Map(m => m.MlbAmId).Name("MLBAMID").TypeConverter<DefaultIntConverter>();
      Map(m => m.FullName).Name("Player");
      Map(m => m.Age).Name("Age").TypeConverter<DefaultIntConverter>();
      Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
      // Skipped stat fields:	PA,OBP,SLG,OPS,BB%,Ct%,Eye,H%,HctX,xBA,GB %,LD %,FB %,xPX,SPD,RCG,RAR,BPV,C,1B,2B,3B,SS,OF,DH
      Map(m => m.YearToDateBattingStats.AtBats).Name("AB").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.Runs).Name("R").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.Hits).Name("H").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.Doubles).Name("2B").NameIndex(1).TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.Triples).Name("3B").NameIndex(1).TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.HomeRuns).Name("HR").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.RunsBattedIn).Name("RBI").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.BaseOnBalls).Name("BB").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.StrikeOuts).Name("K").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.StolenBases).Name("SB").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.CaughtStealing).Name("CS").TypeConverter<DefaultIntConverter>();
      Map(m => m.YearToDateBattingStats.ContractRate).Name("Ct%").TypeConverter<RateConverter>();
      Map(m => m.YearToDateBattingStats.Power).Name("PX").TypeConverter<DefaultDoubleConverter>();
      Map(m => m.YearToDateBattingStats.Speed).Name("RSPD").TypeConverter<DefaultDoubleConverter>();
    }
  }
}
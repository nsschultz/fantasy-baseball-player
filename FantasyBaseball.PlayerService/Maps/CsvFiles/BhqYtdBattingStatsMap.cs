using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for BHQ's year to date batting file.</summary>
public class BhqYtdBattingsStatsMap : YtdStatsMapping
{
  /// <summary>Creates a new instance of the mapper.</summary>
  public BhqYtdBattingsStatsMap() => CreateMap();

  private void CreateMap()
  {
    MapSharedFields(PlayerType.B);
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
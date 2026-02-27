using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for BHQ's projected batting file.</summary>
public class BhqProjBattingsStatsMap : ProjStatsMapping
{
  /// <summary>Creates a new instance of the mapper.</summary>
  public BhqProjBattingsStatsMap() => CreateMap();

  private void CreateMap()
  {
    MapSharedFields(PlayerType.B);
    // Skipped stat fields:	PA,AVG,OBP,SLG,OPS,BB%,ct%,Eye,h%,SPD,G%,L%,F%,xBA,BA,RC/G,RAR,BPX
    Map(m => m.ProjectedBattingStats.AtBats).Name("AB").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.Runs).Name("R").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.Hits).Name("H").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.Doubles).Name("2B").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.Triples).Name("3B").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.HomeRuns).Name("HR").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.RunsBattedIn).Name("RBI").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.BaseOnBalls).Name("BB").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.StrikeOuts).Name("K").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.StolenBases).Name("SB").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.CaughtStealing).Name("CS").TypeConverter<DefaultIntConverter>();
    Map(m => m.ProjectedBattingStats.Power).Name("PX").TypeConverter<DefaultDoubleConverter>();
    Map(m => m.ProjectedBattingStats.Speed).Name("RSpd").TypeConverter<DefaultDoubleConverter>();
  }
}
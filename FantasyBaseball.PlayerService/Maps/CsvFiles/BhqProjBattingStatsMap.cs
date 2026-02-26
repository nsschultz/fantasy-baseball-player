using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps;

/// <summary>Mapper for BHQ's projected batting file.</summary>
public class BhqProjBattingsStatsMap : ClassMap<CsvBaseballPlayer>
{
  /// <summary>Creates a new instance of the mapper.</summary>
  public BhqProjBattingsStatsMap() => CreateMap();

  private void CreateMap()
  {
    // Constants
    Map(m => m.Type).Constant(PlayerType.B);
    Map(m => m.Status).Constant(PlayerStatus.NE);
    // Skipped player fields: Bats,Lg,Pos,LY5,LY10,LY15,LY20,LIMA,DL,12$,15$
    Map(m => m.MlbAmId).Name("MLBAMID").TypeConverter<DefaultIntConverter>();
    Map(m => m.FullName).Name("Player");
    Map(m => m.Age).Name("Age").TypeConverter<DefaultIntConverter>();
    Map(m => m.Team).Name("Team").TypeConverter<BaseballTeamConverter>();
    Map(m => m.Reliability).Name("MM Code").TypeConverter<ReliabilityConverter>();
    Map(m => m.MayberryMethod).Name("MM").TypeConverter<DefaultIntConverter>();
    Map(m => m.AverageDraftPick).Name("ADP").TypeConverter<DefaultDoubleConverter>();
    Map(m => m.AverageDraftPickMin).Name("Min ADP").TypeConverter<DefaultIntConverter>();
    Map(m => m.AverageDraftPickMax).Name("Max ADP").TypeConverter<DefaultIntConverter>();
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
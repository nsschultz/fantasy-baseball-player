using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for existing/outgoing file.</summary>
public abstract class ProjStatsMapping : ClassMap<CsvBaseballPlayer>
{
  protected void MapSharedFields(PlayerType type)
  {
    // Constants
    Map(m => m.Type).Constant(type);
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
  }
}
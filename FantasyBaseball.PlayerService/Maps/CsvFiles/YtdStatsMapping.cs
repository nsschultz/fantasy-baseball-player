using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvFiles;

/// <summary>Mapper for existing/outgoing file.</summary>
public abstract class YtdStatsMapping : ClassMap<CsvBaseballPlayer>
{
  protected void MapSharedFields(PlayerType type)
  {
    // Constants
    Map(m => m.Type).Constant(type);
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
  }
}
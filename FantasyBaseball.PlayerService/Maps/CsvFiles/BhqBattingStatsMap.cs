using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.Converters;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps.CsvMaps
{
  /// <summary>Mapper for BHQ's batting file.</summary>
  public class BhqBattingStatsMap : ClassMap<CsvBaseballPlayer>
  {
    /// <summary>Creates a new instance of the mapper.</summary>
    public BhqBattingStatsMap()
    {
      Map(m => m.BhqId).Name("PLAYERPLAYERID");
      Map(m => m.Type).Name("PLAYERPLAYERID").Constant(PlayerType.B);
      Map(m => m.Status).Name("PLAYERPLAYERID").Constant(PlayerStatus.NE);
      Map(m => m.LastName).Name("PLAYERLASTNAME");
      Map(m => m.FirstName).Name("PLAYERFIRSTNAME");
      Map(m => m.Age).Name("PLAYERAGE");
      Map(m => m.Team).Name("PLAYERTM").TypeConverter<BaseballTeamConverter>();
      Map(m => m.Reliability).Name("PLAYERMM CODE").TypeConverter<ReliabilityConverter>();
      Map(m => m.MayberryMethod).Name("PLAYERMM");
      Map(m => m.YearToDateBattingStats.AtBats).Name("YTDAB");
      Map(m => m.YearToDateBattingStats.Runs).Name("YTDR");
      Map(m => m.YearToDateBattingStats.Hits).Name("YTDH");
      Map(m => m.YearToDateBattingStats.Doubles).Name("YTD2B");
      Map(m => m.YearToDateBattingStats.Triples).Name("YTD3B");
      Map(m => m.YearToDateBattingStats.HomeRuns).Name("YTDHR");
      Map(m => m.YearToDateBattingStats.RunsBattedIn).Name("YTDRBI");
      Map(m => m.YearToDateBattingStats.BaseOnBalls).Name("YTDBB");
      Map(m => m.YearToDateBattingStats.StrikeOuts).Name("YTDK");
      Map(m => m.YearToDateBattingStats.StolenBases).Name("YTDSB");
      Map(m => m.YearToDateBattingStats.CaughtStealing).Name("YTDCS");
      Map(m => m.YearToDateBattingStats.Power).Name("YTDPX");
      Map(m => m.YearToDateBattingStats.Speed).Name("YTDSPD");
      Map(m => m.ProjectedBattingStats.AtBats).Name("PROJAB");
      Map(m => m.ProjectedBattingStats.Runs).Name("PROJR");
      Map(m => m.ProjectedBattingStats.Hits).Name("PROJH");
      Map(m => m.ProjectedBattingStats.Doubles).Name("PROJ2B");
      Map(m => m.ProjectedBattingStats.Triples).Name("PROJ3B");
      Map(m => m.ProjectedBattingStats.HomeRuns).Name("PROJHR");
      Map(m => m.ProjectedBattingStats.RunsBattedIn).Name("PROJRBI");
      Map(m => m.ProjectedBattingStats.BaseOnBalls).Name("PROJBB");
      Map(m => m.ProjectedBattingStats.StrikeOuts).Name("PROJK");
      Map(m => m.ProjectedBattingStats.StolenBases).Name("PROJSB");
      Map(m => m.ProjectedBattingStats.CaughtStealing).Name("PROJCS");
      Map(m => m.ProjectedBattingStats.Power).Name("PROJPX");
      Map(m => m.ProjectedBattingStats.Speed).Name("PROJSPD");
    }
  }
}
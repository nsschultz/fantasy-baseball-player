using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for uploading new stats for players.</summary>
/// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
[Route("api/v3/action/upload/stats")]
[ApiController]
public class PlayerUploadStatsController(IMergeStatsService mergeService) : ControllerBase
{
  /// <summary>Uploads player statistics from a file.</summary>
  /// <param name="player">The type of player.</param>
  /// <param name="stats">The type of statistics.</param>
  /// <returns>The number of records merged.</returns>
  [HttpPost]
  public async Task<int> UploadStats(PlayerType player, StatsType stats)
  {
    try
    {
      if (player == PlayerType.U) throw new BadRequestException("Invalid player type");
      if (stats == StatsType.UNKN) throw new BadRequestException("Invalid stats type");
      return await mergeService.MergeStats(new FormFileReader(Request), player, stats);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw new BadRequestException("Invalid file type");
    }
  }
}
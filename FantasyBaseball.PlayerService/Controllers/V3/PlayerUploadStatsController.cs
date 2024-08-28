using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for taking actions on the player objects.</summary>
  [Route("api/v2/action/upload/stats")]
  [Route("api/v3/action/upload/stats")]
  [ApiController]
  public class PlayerUploadStatsController : ControllerBase
  {
    private readonly IMergeStatsService _mergeService;

    /// <summary>Creates a new instance of the <see cref="PlayerUploadStatsController"/> class.</summary>
    /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
    public PlayerUploadStatsController(IMergeStatsService mergeService) => (_mergeService) = (mergeService);

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
        return await _mergeService.MergeStats(new FormFileReader(Request), player, stats);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw new BadRequestException("Invalid file type");
      }
    }
  }
}
using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for uploading new stats for players.</summary>
/// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
/// <param name="logger">Logger for upload failures.</param>
[Route("api/v3/action/upload/stats")]
[ApiController]
public class PlayerUploadStatsController(IMergeStatsService mergeService, ILogger<PlayerUploadStatsController> logger) : ControllerBase
{
    /// <summary>Uploads player statistics from a file.</summary>
    /// <param name="player">The type of player.</param>
    /// <param name="stats">The type of statistics.</param>
    /// <returns>The number of records merged.</returns>
    [HttpPost]
    public async Task<int> UploadStats([FromQuery] PlayerType player, [FromQuery] StatsType stats)
    {
        if (player == PlayerType.U) throw new BadRequestException("Invalid player type");
        if (stats == StatsType.UNKN) throw new BadRequestException("Invalid stats type");
        try
        {
            return await mergeService.MergeStats(new FormFileReader(Request), player, stats);
        }
        catch (BadRequestException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Failed to merge {StatsType} statistics for player type {PlayerType}", stats, player);
            throw new BadRequestException("Invalid file type");
        }
    }
}
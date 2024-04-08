using System;
using System.Net.Mime;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for taking actions on the player objects.</summary>
  [ApiController]
  public class PlayerActionController : ControllerBase
  {
    private readonly ICsvFileWriterService _writerService;
    private readonly IGetPlayerService _getService;
    private readonly IMergeStatsService _mergeService;

    /// <summary>Creates a new instance of the <see cref="PlayerActionController"/> class.</summary>
    /// <param name="getService">Service for getting players.</param>
    /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
    /// <param name="writerService">The service for writing the CSV file.</param>
    public PlayerActionController(IGetPlayerService getService, ICsvFileWriterService writerService, IMergeStatsService mergeService) =>
      (_getService, _mergeService, _writerService) = (getService, mergeService, writerService);

    /// <summary>Exports the players as a CSV file.</summary>
    /// <returns>A CSV file containing the players.</returns>
    [HttpGet("api/v2/action/export")]
    public async Task<IActionResult> ExportPlayers()
    {
      var players = await _getService.GetPlayers();
      var fileContent = _writerService.WriteCsvData(players);
      Response.Headers.Append("Content-Disposition", new ContentDisposition { FileName = "players.csv", Inline = false }.ToString());
      return File(fileContent, "application/octet-stream", "players.csv");
    }

    /// <summary>Overwrites the underlying batter.csv file.</summary>
    [HttpPost("api/v2/action/upload/projection/batters")]
    [Obsolete("Use the api/v2/action/upload/stats endpoint instead.")]
    public async Task<int> UploadBatterFile() => await UploadFile(PlayerType.B, StatsType.PROJ);

    /// <summary>Overwrites the underlying pitcher.csv file.</summary>
    [HttpPost("api/v2/action/upload/projection/pitchers")]
    [Obsolete("Use the api/v2/action/upload/stats endpoint instead.")]
    public async Task<int> UploadPitcherFile() => await UploadFile(PlayerType.P, StatsType.PROJ);

    /// <summary>Uploads player statistics from a file.</summary>
    /// <param name="player">The type of player.</param>
    /// <param name="stats">The type of statistics.</param>
    /// <returns>The number of records merged.</returns>
    [HttpPost("api/v2/action/upload/stats")]
    public async Task<int> UploadStats(PlayerType player, StatsType stats)
    {
      if (player == PlayerType.U) throw new BadRequestException("Invalid player type");
      if (stats == StatsType.UNKN) throw new BadRequestException("Invalid stats type");
      return await UploadFile(player, stats);
    }

    private async Task<int> UploadFile(PlayerType player, StatsType stats)
    {
      try
      {
        var fileReader = new FormFileReader(Request);
        return await _mergeService.MergeStats(fileReader, player, stats);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw new BadRequestException("Invalid file type");
      }
    }
  }
}
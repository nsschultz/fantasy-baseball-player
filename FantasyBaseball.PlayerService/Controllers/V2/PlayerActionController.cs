using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for taking actions on the player objects.</summary>
  [Route("api/v2/action")]
  [ApiController]
  public class PlayerActionController : ControllerBase
  {
    private readonly IMergeStatsService _mergeService;

    /// <summary>Creates a new instance of the <see cref="PlayerActionController"/> class.</summary>
    /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
    public PlayerActionController(IMergeStatsService mergeService) => (_mergeService) = (mergeService);

    /// <summary>Overwrites the underlying batter.csv file.</summary>
    [HttpPost("upload/projection/batters")]
    [Obsolete("Use the api/v3/action/upload/stats endpoint instead.")]
    public async Task<int> UploadBatterFile() => await UploadFile(PlayerType.B, StatsType.PROJ);

    /// <summary>Overwrites the underlying pitcher.csv file.</summary>
    [HttpPost("upload/projection/pitchers")]
    [Obsolete("Use the api/v3/action/upload/stats endpoint instead.")]
    public async Task<int> UploadPitcherFile() => await UploadFile(PlayerType.P, StatsType.PROJ);

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
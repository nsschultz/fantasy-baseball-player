using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for retrieving player data.</summary>
  /// <remarks>Creates a new instance of the controller.</remarks>
  /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
  [ApiController]
  public class PlayerActionController(IMergeProjectionService mergeService) : ControllerBase
  {
    private readonly IMergeProjectionService _mergeService = mergeService;

    /// <summary>Overwrites the underlying batter.csv file.</summary>
    [HttpPost("api/v2/action/upload/projection/batters")]
    public async Task<int> UploadBatterFile() => await UploadFile(PlayerType.B);

    /// <summary>Overwrites the underlying pitcher.csv file.</summary>
    [HttpPost("api/v2/action/upload/projection/pitchers")]
    public async Task<int> UploadPitcherFile() => await UploadFile(PlayerType.P);

    private async Task<int> UploadFile(PlayerType type)
    {
      try
      {
        var fileReader = new FormFileReader(Request);
        return await _mergeService.MergeProjection(fileReader, type);
      }
      catch (Exception)
      {
        throw new BadRequestException("Invalid file type");
      }
    }
  }
}
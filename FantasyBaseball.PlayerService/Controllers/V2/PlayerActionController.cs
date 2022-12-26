using System;
using System.Net.Mime;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for retrieving player data.</summary>
  [ApiController]
  public class PlayerActionController : ControllerBase
  {
    private readonly ICsvFileWriterService _writerService;
    private readonly IGetPlayersService _getService;
    private readonly IMergeProjectionService _mergeService;


    /// <summary>Creates a new instance of the controller.</summary>
    /// <param name="getService">Service for getting players.</param>
    /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
    /// <param name="writerService">The service for writting the CSV file.</param>
    public PlayerActionController(IGetPlayersService getService, ICsvFileWriterService writerService, IMergeProjectionService mergeService) =>
      (_getService, _mergeService, _writerService) = (getService, mergeService, writerService);

    /// <summary>Export the players as a CSV file.</summary>
    /// <returns>A CSV file containing the players.</returns>
    [HttpGet("api/v2/action/export")]
    public async Task<IActionResult> ExportPlayers()
    {
      var players = await _getService.GetPlayers();
      var fileContent = _writerService.WriteCsvData(players);
      Response.Headers.Add("Content-Disposition", new ContentDisposition { FileName = "players.csv", Inline = false }.ToString());
      return File(fileContent, "application/octet-stream", "players.csv");
    }

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
using System.Net.Mime;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for retrieving player data.</summary>
  [Route("api/v1/action/export")]
  [Route("api/v2/action/export")]
  [ApiController]
  public class PlayerExportController : ControllerBase
  {
    private readonly ICsvFileWriterService _writerService;
    private readonly IGetPlayersService _getService;

    /// <summary>Creates a new instance of the controller.</summary>
    /// <param name="getService">Service for getting players.</param>
    /// <param name="writerService">The service for writting the CSV file.</param>
    public PlayerExportController(IGetPlayersService getService, ICsvFileWriterService writerService) =>
      (_getService, _writerService) = (getService, writerService);

    /// <summary>Export the players as a CSV file.</summary>
    /// <returns>A CSV file containing the players.</returns>
    [HttpGet]
    public async Task<IActionResult> ExportPlayers()
    {
      var players = await _getService.GetPlayers();
      var fileContent = _writerService.WriteCsvData(players);
      Response.Headers.Add("Content-Disposition", new ContentDisposition { FileName = "players.csv", Inline = false }.ToString());
      return File(fileContent, "application/octet-stream", "players.csv");
    }
  }
}
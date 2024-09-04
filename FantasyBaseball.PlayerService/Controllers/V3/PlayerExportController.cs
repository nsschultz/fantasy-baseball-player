using System.Net.Mime;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for taking actions on the player objects.</summary>
  [Route("api/v3/action/export")]
  [ApiController]
  public class PlayerExportController : ControllerBase
  {
    private readonly ICsvFileWriterService _writerService;
    private readonly IGetPlayerService _getService;

    /// <summary>Creates a new instance of the <see cref="PlayerExportController"/> class.</summary>
    /// <param name="getService">Service for getting players.</param>
    /// <param name="writerService">The service for writing the CSV file.</param>
    public PlayerExportController(IGetPlayerService getService, ICsvFileWriterService writerService) =>
      (_getService, _writerService) = (getService, writerService);

    /// <summary>Exports the players as a CSV file.</summary>
    /// <returns>A CSV file containing the players.</returns>
    [HttpGet]
    public async Task<IActionResult> ExportPlayers()
    {
      var players = await _getService.GetPlayers();
      var fileContent = _writerService.WriteCsvData(players);
      Response.Headers.Append("Content-Disposition", new ContentDisposition { FileName = "players.csv", Inline = false }.ToString());
      return File(fileContent, "application/octet-stream", "players.csv");
    }
  }
}
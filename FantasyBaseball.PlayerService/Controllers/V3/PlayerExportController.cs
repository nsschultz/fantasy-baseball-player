using System.Net.Mime;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for taking actions on the player objects.</summary>
[Route("api/v3/action/export")]
[ApiController]
public class PlayerExportController(IGetPlayerService getService, ICsvFileWriterService writerService) : ControllerBase
{
  /// <summary>Exports the players as a CSV file.</summary>
  /// <returns>A CSV file containing the players.</returns>
  [HttpGet]
  public async Task<IActionResult> ExportPlayers()
  {
    var players = await getService.GetPlayers();
    var fileContent = writerService.WriteCsvData(players);
    Response.Headers.Append("Content-Disposition", new ContentDisposition { FileName = "players.csv", Inline = false }.ToString());
    return File(fileContent, "application/octet-stream", "players.csv");
  }
}
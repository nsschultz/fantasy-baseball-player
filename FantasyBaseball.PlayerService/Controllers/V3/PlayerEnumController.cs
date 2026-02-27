using System.Collections.Generic;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for retrieving enum data relevant to players.</summary>
/// <param name="getEnumMapService">Service for getting the enums as a dictionary.</param>
[Route("api/v3/enum-map")]
[ApiController]
public class PlayerEnumController(IGetPlayerEnumMapService getEnumMapService) : ControllerBase
{
  /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
  /// <param name="enumType">The type of enum to return.</param>
  /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
  [HttpGet] public Dictionary<int, string> GetPlayersEnumMap(string enumType) => getEnumMapService.GetPlayerEnumMap(enumType);
}
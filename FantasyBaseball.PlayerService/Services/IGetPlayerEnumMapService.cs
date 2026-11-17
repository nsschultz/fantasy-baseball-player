using System.Collections.Generic;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting the enums as a dictionary.</summary>
public interface IGetPlayerEnumMapService
{
    /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
    /// <param name="enumType">The type of enum to return. Supported values (case-insensitive): "LeagueStatus", "PlayerStatus", "PlayerType", "StatsType". Returns an empty dictionary if the enum type is not recognized.</param>
    /// <returns>A dictionary of the enum values (key) and descriptions (value) for the given enum type, or an empty dictionary if the type is not recognized.</returns>
    Dictionary<int, string> GetPlayerEnumMap(string enumType);
}
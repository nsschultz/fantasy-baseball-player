using System.Collections.Generic;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Utility;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting the enums as a dictionary.</summary>
public class GetPlayerEnumMapService : IGetPlayerEnumMapService
{
    /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
    /// <param name="enumType">The type of enum to return. Supported values (case-insensitive): "LeagueStatus", "PlayerStatus", "PlayerType", "StatsType". Returns an empty dictionary if the enum type is not recognized.</param>
    /// <returns>A dictionary of the enum values (key) and descriptions (value) for the given enum type, or an empty dictionary if the type is not recognized.</returns>
    public Dictionary<int, string> GetPlayerEnumMap(string enumType) =>
      enumType?.ToUpperInvariant() switch
      {
          "LEAGUESTATUS" => EnumHelper.GetValuesAsDictionary<LeagueStatus>(),
          "PLAYERSTATUS" => EnumHelper.GetValuesAsDictionary<PlayerStatus>(),
          "PLAYERTYPE" => EnumHelper.GetValuesAsDictionary<PlayerType>(),
          "STATSTYPE" => EnumHelper.GetValuesAsDictionary<StatsType>(),
          _ => []
      };
}
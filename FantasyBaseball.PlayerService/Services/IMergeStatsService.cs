using System.Threading.Tasks;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for merging a CSV file into the existing data store.</summary>
public interface IMergeStatsService
{
  /// <summary>Reads in data from the given CSV file and merges it into the existing data store.</summary>
  /// <param name="fileReader">Helper for reading the contents of a file.</param>
  /// <param name="player">The type of player to update.</param>
  /// <param name="stats">The type of stats being loaded.</param>
  /// <returns>The count of players from the file that were merged in.</returns>
  Task<int> MergeStats(IFileReader fileReader, PlayerType player, StatsType stats);
}
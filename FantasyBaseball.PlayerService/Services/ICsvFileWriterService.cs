using System.Collections.Generic;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for writing the CSV file.</summary>
  public interface ICsvFileWriterService
  {
    /// <summary>Reads in data from the given CSV file.</summary>
    /// <param name="players">All of the players to to write to the CSV.</param>
    /// <returns>A byte array of the file content.</returns>
    byte[] WriteCsvData(List<BaseballPlayer> players);
  }
}
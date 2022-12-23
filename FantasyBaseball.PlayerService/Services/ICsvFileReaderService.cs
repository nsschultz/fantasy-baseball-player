using System.Collections.Generic;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for reading CSV file.</summary>
  public interface ICsvFileReaderService
  {
    /// <summary>Reads in data from the given CSV file.</summary>
    /// <param name="map">The map used to read in the data and create the POCO accordingly.</param>
    /// <param name="fileReader">Helper for reading the contents of a file.</param>
    /// <returns>All of the data within the given file.</returns>
    Task<List<CsvBaseballPlayer>> ReadCsvData(ClassMap map, IFileReader fileReader);
  }
}
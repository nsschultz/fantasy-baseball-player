using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for reading CSV file.</summary>
  public class CsvFileReaderService : ICsvFileReaderService
  {
    /// <summary>Reads in data from the given CSV file.</summary>
    /// <param name="map">The map used to read in the data and create the POCO accordingly.</param>
    /// <param name="fileReader">Helper for reading the contents of a file.</param>
    /// <returns>All of the data within the given file.</returns>
    public async Task<List<CsvBaseballPlayer>> ReadCsvData(ClassMap map, IFileReader fileReader)
    {
      var lines = await fileReader.ReadLines();
      using var stream = new StringReader(string.Join(Environment.NewLine, lines.Take(lines.Count - 1)));
      using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
      csv.Context.RegisterClassMap(map);
      return csv.GetRecords<CsvBaseballPlayer>().ToList();
    }
  }
}
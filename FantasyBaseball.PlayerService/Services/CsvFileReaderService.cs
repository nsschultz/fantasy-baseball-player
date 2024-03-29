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
      using var stream = await FixBhqFile(fileReader);
      using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
      csv.Context.RegisterClassMap(map);
      return csv.GetRecords<CsvBaseballPlayer>().ToList();
    }

    private static IEnumerable<string> FindHeaderRows(IEnumerable<string> lines) =>
      lines.Where(l => l.StartsWith("Player")).Select(l => l.Replace("\"", ""));

    /// <summary>Reads in the file and merges the multiple header rows into a single header.</summary>
    /// <param name="fileReader">Helper for reading the contents of a file.</param>
    /// <returns>A stream containing the header row and the rest of the data.</returns>
    private static async Task<TextReader> FixBhqFile(IFileReader fileReader)
    {
      var lines = await fileReader.ReadLines();
      var headers = MergeHeaderRows(FindHeaderRows(lines));
      headers.AddRange(lines.Where(l => !l.StartsWith("Player")).Where(l => !l.StartsWith("(Generated")));
      return new StringReader(string.Join(Environment.NewLine, headers));
    }

    private static List<string> MergeHeaderRows(IEnumerable<string> headerRows)
    {
      var headerColumns = headerRows.Select(l => l.Split(",")).Select(l => l.ToList()).ToList();
      var headers = new List<string>();
      for (var i = 0; i < headerColumns[0].Count; i++) headers.Add($"{headerColumns[0][i]}{headerColumns[1][i]}".ToUpper());
      return [string.Join(",", headers)];
    }
  }
}
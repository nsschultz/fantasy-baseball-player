using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Maps.CsvFiles;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for writing the CSV file.</summary>
  /// <remarks>Creates a new instance and configures the service.</remarks>
  /// <param name="mapper">Instance of the auto mapper.</param>
  public class CsvFileWriterService(IMapper mapper) : ICsvFileWriterService
  {
    private readonly CsvConfiguration _configuration = new(CultureInfo.CurrentCulture);
    private readonly IMapper _mapper = mapper;

    /// <summary>Reads in data from the given CSV file.</summary>
    /// <param name="players">All of the players to to write to the CSV.</param>
    /// <returns>A byte array of the file content.</returns>
    public byte[] WriteCsvData(List<BaseballPlayer> players)
    {
      players ??= [];
      var csvPlayers = players.Select(p => _mapper.Map<CsvBaseballPlayer>(p));
      using var stream = new MemoryStream();
      using var writer = new StreamWriter(stream);
      using var csv = new CsvWriter(writer, _configuration);
      csv.Context.RegisterClassMap<ExportedPlayerMap>();
      csv.WriteRecords(csvPlayers);
      writer.Flush();
      return stream.ToArray();
    }
  }
}
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Maps.Converters
{
  /// <summary>Converts the key or description to a LeagueStatus.</summary>
  public class PositionListConverter : DefaultTypeConverter
  {
    /// <summary>Converts the object to a string.</summary>
    /// <param name="text">The string to convert to an object.</param>
    /// <param name="row">The <see cref="IWriterRow"/> for the current record.</param>
    /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being written.</param>
    /// <returns>The string representation of the object.</returns>
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
      string.IsNullOrEmpty(text)
        ? new List<BaseballPosition>()
        : text.Split("-").Select(p => new BaseballPosition { Code = p.Trim().ToUpper() }).ToList();

    /// <summary>Converts the string to an object.</summary>
    /// <param name="value">The object to convert to a string.</param>
    /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
    /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
    /// <returns>The object created from the string.</returns>
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
      if (value == null || !(value is List<BaseballPosition>)) return "";
      var positions = (List<BaseballPosition>)value;
      if (positions.Count == 0) return "";
      return string.Join("-", positions.OrderBy(p => p.SortOrder).Select(p => p.Code));
    }
  }
}
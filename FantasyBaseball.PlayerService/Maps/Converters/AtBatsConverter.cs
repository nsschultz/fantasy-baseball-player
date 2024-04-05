using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace FantasyBaseball.PlayerService.Maps.Converters
{
  /// <summary>Generates At Bats based on a couple of fields (when ABs doesn't exist).</summary>
  public class AtBatsConverter : DefaultTypeConverter
  {
    /// <summary>Converts the object to a string.</summary>
    /// <param name="text">The string to convert to an object.</param>
    /// <param name="row">The <see cref="IWriterRow"/> for the current record.</param>
    /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being written.</param>
    /// <returns>The string representation of the object.</returns>
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
      var pa = GetIntValue(text);
      if (pa == 0) return 0;
      var h = GetIntValue(row, "H");
      var bb = GetIntValue(row, "BB");
      if (h == 0) return pa - bb;
      var avg = double.TryParse(row.GetField("AVG"), out var d) ? d : 0;
      if (avg == 0.0 && h > 0) avg = 1.0; // Fix for issue where BHQ has wrong average
      return Convert.ToInt32(Math.Round(h / avg + .5, MidpointRounding.ToZero));
    }

    /// <summary>Converts the string to an object.</summary>
    /// <param name="value">The object to convert to a string.</param>
    /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
    /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
    /// <returns>The object created from the string.</returns>
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) => value.ToString();

    private static int GetIntValue(IReaderRow row, string fieldName) => GetIntValue(row.GetField(fieldName));

    private static int GetIntValue(string value) => int.TryParse(value, out var i) ? i : 0;
  }
}
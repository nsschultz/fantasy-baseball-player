using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FantasyBaseball.Common.Enums;

namespace FantasyBaseball.PlayerService.Maps.Converters
{
    /// <summary>Converts the key or description to a LeagueStatus.</summary>
    public class LeagueStatusConverter : DefaultTypeConverter
    {
        /// <summary>Converts the object to a string.</summary>
        /// <param name="text">The string to convert to an object.</param>
        /// <param name="row">The <see cref="IWriterRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being written.</param>
        /// <returns>The string representation of the object.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var fromKey = EnumUtility.GetFromKey<LeagueStatus>(text?.Trim());
            var fromDesc = EnumUtility.GetFromDescription<LeagueStatus>(text?.Trim());
            return fromKey > fromDesc ? fromKey : fromDesc;
        }

        /// <summary>Converts the string to an object.</summary>
        /// <param name="value">The object to convert to a string.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The object created from the string.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) => value?.ToString() ?? "A";
    }
}
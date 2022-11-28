using System.Threading.Tasks;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for merging the CSV file into the existing data store.</summary>
    public interface IMergeProjectionService
    {
        /// <summary>Reads in data from the given CSV file and merges it into the existing data store.</summary>
        /// <param name="fileReader">Helper for reading the contents of a file.</param>
        /// <param name="type">The type of player to update.</param>
        /// <returns>The count of players from the file that were merged in.</returns>
        Task<int> MergeProjection(IFileReader fileReader, PlayerType type);
    }
}
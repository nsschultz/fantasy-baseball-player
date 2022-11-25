using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;

using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
    /// <summary>Endpoint for merging player projection stats dat into existing data store.</summary>
    [ApiController]
    public class PlayerProjectionController : ControllerBase
    {
        private readonly IMergeProjectionService _mergeService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="mergeService">Service for merging the CSV file into the existing data store.</param>
        public PlayerProjectionController(IMergeProjectionService mergeService) => _mergeService = mergeService;

        /// <summary>Overwrites the underlying batter.csv file.</summary>
        [HttpPost("api/v1/projection/batters/upload")]
        [HttpPost("api/v2/action/upload/projections/batter")]
        public async Task<int> UploadBatterFile() => await UploadFile(PlayerType.B);

        /// <summary>Overwrites the underlying pitcher.csv file.</summary>
        [HttpPost("api/v1/projection/pitchers/upload")]
        [HttpPost("api/v2/action/upload/projections/pitcher")]
        public async Task<int> UploadPitcherFile() => await UploadFile(PlayerType.P);

        private async Task<int> UploadFile(PlayerType type)
        {
            try
            {
                var fileReader = new FormFileReader(Request);
                return await _mergeService.MergeProjection(fileReader, type);
            }
            catch (Exception)
            {
                throw new BadRequestException("Invalid file type");
            }
        }
    }
}
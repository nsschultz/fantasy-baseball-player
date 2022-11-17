using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Maps
{
    /// <summary>A new profile for the player objects.</summary>
    public class BaseballPlayerV1Profile : Profile
    {
        /// <summary>Create a new instance of the profile.</summary>
        public BaseballPlayerV1Profile()
        {
            CreateMap<BaseballPlayer, BaseballPlayerV1>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src => ConvertPositionsToV1(src.Positions)))
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team.Code));
            CreateMap<BaseballPlayerV1, BaseballPlayer>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src => ConvertPositionsFromV1(src.Positions)))
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => new BaseballTeam { Code = src.Team }));
        }

        private static List<BaseballPosition> ConvertPositionsFromV1(string positions) =>
            string.IsNullOrEmpty(positions)
                ? new List<BaseballPosition>()
                : positions.Split("-").Select(p => new BaseballPosition { Code = p }).ToList();

        private static string ConvertPositionsToV1(List<BaseballPosition> positions) =>
            string.Join("-", positions.Select(p => p?.Code).Select(p => p.ToUpper()));
    }
}
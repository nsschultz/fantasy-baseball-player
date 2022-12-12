using AutoMapper;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Maps
{
  /// <summary>A new profile for the CSV Player objects.</summary>
  public class CsvBaseballPlayerProfile : Profile
  {
    /// <summary>Create a new instance of the profile.</summary>
    public CsvBaseballPlayerProfile()
    {
      CreateMap<BaseballPlayerV2, CsvBaseballPlayer>()
        .ForMember(dest => dest.CombinedBattingStats, opt => opt.Ignore())
        .ForMember(dest => dest.CombinedPitchingStats, opt => opt.Ignore())
        .ForMember(dest => dest.ProjectedBattingStats, opt => opt.Ignore())
        .ForMember(dest => dest.ProjectedPitchingStats, opt => opt.Ignore())
        .ForMember(dest => dest.YearToDateBattingStats, opt => opt.Ignore())
        .ForMember(dest => dest.YearToDatePitchingStats, opt => opt.Ignore());
    }
  }
}
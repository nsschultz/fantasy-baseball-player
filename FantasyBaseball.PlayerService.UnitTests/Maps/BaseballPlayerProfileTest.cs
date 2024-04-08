using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Maps.UnitTests
{
  public class BaseballPlayerProfileTest
  {
    private readonly IMapper _mapper;

    public BaseballPlayerProfileTest() => _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerProfile())).CreateMapper();

    [Fact] public void ConvertBaseballPlayerNullTest() => Assert.Null(_mapper.Map<BaseballPlayer>(null));

    [Theory]
    [InlineData(10, PlayerType.B)]
    [InlineData(100, PlayerType.P)]
    public void ConvertBaseballPlayerValidTest(int value, PlayerType type)
    {
      var player = BuildPlayer(value, type);
      ValidatePlayer(value, player, _mapper.Map<BaseballPlayer>(player));
    }

    private static PlayerEntity BuildPlayer(int value, PlayerType type) =>
      new()
      {
        Id = Guid.NewGuid(),
        BhqId = value,
        FirstName = $"First-{value}",
        LastName = $"Last-{value}",
        Age = value,
        Type = type,
        Positions = type == PlayerType.B ? BuildPositionList(["XX", "OF", "1B"]) : BuildPositionList(["SP", "XX", "RP"]),
        Team = type == PlayerType.B ? "MIL" : "TB",
        PlayerTeam = type == PlayerType.B
          ? new TeamEntity { Code = "MIL", LeagueId = "NL", City = "Milwaukee", Nickname = "Brewers" }
          : new TeamEntity { Code = "TB", LeagueId = "AL", City = "Tampa Bay", Nickname = "Rays", AlternativeCode = "TAM" },
        Status = value == 10 ? PlayerStatus.XX : PlayerStatus.IL,
        AverageDraftPick = value + 2,
        AverageDraftPickMin = value + 1,
        AverageDraftPickMax = value + 3,
        MayberryMethod = value + 5,
        Reliability = value + 6,
        LeagueStatuses = [new() { LeagueId = value == 10 ? 1 : 2, LeagueStatus = value == 10 ? LeagueStatus.R : LeagueStatus.X }],
        BattingStats =
        [
          new()
          {
            StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
            AtBats = 300,
            Runs = 75,
            Hits = 96,
            Doubles = 24,
            Triples = 6,
            HomeRuns = 12,
            RunsBattedIn = 48,
            BaseOnBalls = 30,
            StrikeOuts = 60,
            StolenBases = 9,
            CaughtStealing = 3,
            Power = 100,
            Speed = 61
          }
        ],
        PitchingStats =
        [
          new()
          {
            StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
            Wins = 12,
            Losses = 6,
            QualityStarts = 18,
            Saves = 9,
            BlownSaves = 3,
            Holds = 15,
            InningsPitched = 60,
            HitsAllowed = 45,
            EarnedRuns = 24,
            HomeRunsAllowed = 1,
            BaseOnBallsAllowed = 30,
            StrikeOuts = 120,
            FlyBallRate = 0.2,
            GroundBallRate = 0.31
          }
        ]
      };

    private static List<PlayerPositionEntity> BuildPositionList(string[] positions) =>
      positions.Select(p => new PlayerPositionEntity { PositionCode = p }).ToList();

    private static void ValidatePlayer(int value, PlayerEntity expected, BaseballPlayer actual)
    {
      Assert.Equal(expected.Id, actual.Id);
      Assert.Equal(expected.BhqId, actual.BhqId);
      Assert.Equal(expected.FirstName, actual.FirstName);
      Assert.Equal(expected.LastName, actual.LastName);
      Assert.Equal(expected.Age, actual.Age);
      Assert.Equal(expected.Type, actual.Type);
      Assert.Empty(actual.Positions);
      Assert.Equal(expected.PlayerTeam.AlternativeCode, actual.Team.AlternativeCode);
      Assert.Equal(expected.PlayerTeam.City, actual.Team.City);
      Assert.Equal(expected.PlayerTeam.Code, actual.Team.Code);
      Assert.Equal(expected.PlayerTeam.LeagueId, actual.Team.LeagueId);
      Assert.Equal(expected.PlayerTeam.Nickname, actual.Team.Nickname);
      Assert.Equal(expected.Status, actual.Status);
      Assert.Equal(expected.AverageDraftPick, actual.AverageDraftPick);
      Assert.Equal(expected.AverageDraftPickMax, actual.AverageDraftPickMax);
      Assert.Equal(expected.AverageDraftPickMin, actual.AverageDraftPickMin);
      Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
      Assert.Equal(expected.Reliability, actual.Reliability);
      Assert.Equal(value == 10 ? expected.LeagueStatuses.First().LeagueStatus : LeagueStatus.A, actual.League1);
      Assert.Equal(value != 10 ? expected.LeagueStatuses.First().LeagueStatus : LeagueStatus.A, actual.League2);
      ValidatePlayerBattingStats(value == 10 ? expected.BattingStats.First() : new BattingStatsEntity(), actual.BattingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.YTD]);
      ValidatePlayerBattingStats(value != 10 ? expected.BattingStats.First() : new BattingStatsEntity(), actual.BattingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.PROJ]);
      ValidatePlayerBattingStats(expected.BattingStats.First(), actual.BattingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.CMBD]);
      ValidatePlayerPitchingStats(value == 10 ? expected.PitchingStats.First() : new PitchingStatsEntity(), actual.PitchingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.YTD]);
      ValidatePlayerPitchingStats(value != 10 ? expected.PitchingStats.First() : new PitchingStatsEntity(), actual.PitchingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.PROJ]);
      ValidatePlayerPitchingStats(expected.PitchingStats.First(), actual.PitchingStats.ToDictionary(s => s.StatsType, s => s)[StatsType.CMBD]);
    }

    private static void ValidatePlayerBattingStats(BattingStatsEntity expected, BattingStats actual)
    {
      Assert.Equal(expected.AtBats, actual.AtBats);
      Assert.Equal(expected.Runs, actual.Runs);
      Assert.Equal(expected.Hits, actual.Hits);
      Assert.Equal(expected.Doubles, actual.Doubles);
      Assert.Equal(expected.Triples, actual.Triples);
      Assert.Equal(expected.HomeRuns, actual.HomeRuns);
      Assert.Equal(expected.RunsBattedIn, actual.RunsBattedIn);
      Assert.Equal(expected.BaseOnBalls, actual.BaseOnBalls);
      Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
      Assert.Equal(expected.StolenBases, actual.StolenBases);
      Assert.Equal(expected.CaughtStealing, actual.CaughtStealing);
      Assert.Equal(expected.Power, actual.Power);
      Assert.Equal(expected.Speed, actual.Speed);
    }

    private static void ValidatePlayerPitchingStats(PitchingStatsEntity expected, PitchingStats actual)
    {
      Assert.Equal(expected.Wins, actual.Wins);
      Assert.Equal(expected.Losses, actual.Losses);
      Assert.Equal(expected.QualityStarts, actual.QualityStarts);
      Assert.Equal(expected.Saves, actual.Saves);
      Assert.Equal(expected.BlownSaves, actual.BlownSaves);
      Assert.Equal(expected.Holds, actual.Holds);
      Assert.Equal(expected.InningsPitched, actual.InningsPitched);
      Assert.Equal(expected.HitsAllowed, actual.HitsAllowed);
      Assert.Equal(expected.EarnedRuns, actual.EarnedRuns);
      Assert.Equal(expected.HomeRunsAllowed, actual.HomeRunsAllowed);
      Assert.Equal(expected.BaseOnBallsAllowed, actual.BaseOnBallsAllowed);
      Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
      Assert.Equal(expected.FlyBallRate, actual.FlyBallRate);
      Assert.Equal(expected.GroundBallRate, actual.GroundBallRate);
    }
  }
}
using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3
{
  public class PlayerUploadStatsControllerTest
  {
    [Fact]
    public async Task UploadStatsValidTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B), It.Is<StatsType>(i => i == StatsType.YTD)))
        .ReturnsAsync(6);
      var controller = new PlayerUploadStatsController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      Assert.Equal(6, await controller.UploadStats(PlayerType.B, StatsType.YTD));
    }

    [Fact]
    public async Task UploadStatInvalidPlayerTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      var controller = new PlayerUploadStatsController(mergeService.Object);
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.U, StatsType.PROJ));
    }

    [Fact]
    public async Task UploadStatsInvalidStatsTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      var controller = new PlayerUploadStatsController(mergeService.Object);
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.P, StatsType.UNKN));
    }


    [Fact]
    public async Task UploadStatsExceptionTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P), It.Is<StatsType>(i => i == StatsType.YTD)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerUploadStatsController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.P, StatsType.YTD));
    }
  }
}
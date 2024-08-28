using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V2;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V2
{
  public class PlayerActionControllerTest
  {
    [Fact]
    public async Task UploadBattersTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B), It.Is<StatsType>(i => i == StatsType.PROJ)))
        .ReturnsAsync(5);
      var controller = new PlayerActionController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      Assert.Equal(5, await controller.UploadBatterFile());
    }

    [Fact]
    public async Task UploadBattersExceptionTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B), It.Is<StatsType>(i => i == StatsType.PROJ)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerActionController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadBatterFile());
    }

    [Fact]
    public async Task UploadPitchersTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P), It.Is<StatsType>(i => i == StatsType.PROJ)))
        .ReturnsAsync(7);
      var controller = new PlayerActionController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      Assert.Equal(7, await controller.UploadPitcherFile());
    }

    [Fact]
    public async Task UploadPitchersExceptionTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P), It.Is<StatsType>(i => i == StatsType.PROJ)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerActionController(mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadPitcherFile());
    }
  }
}
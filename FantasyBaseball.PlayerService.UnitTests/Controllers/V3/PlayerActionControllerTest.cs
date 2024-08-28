using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3
{
  public class PlayerActionControllerTest
  {

    [Fact]
    public async Task GetFile()
    {
      var fileContent = Encoding.ASCII.GetBytes("file-content");
      var getService = new Mock<IGetPlayerService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync([new()]);
      var writer = new Mock<ICsvFileWriterService>();
      writer.Setup(o => o.WriteCsvData(It.Is<List<BaseballPlayer>>(p => p.Count == 1))).Returns(fileContent);
      var controller = new PlayerActionController(getService.Object, writer.Object, null);
      var headerDictionary = new HeaderDictionary();
      var response = new Mock<HttpResponse>();
      response.SetupGet(r => r.Headers).Returns(headerDictionary);
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Response).Returns(response.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      var result = await controller.ExportPlayers();
      Assert.Equal("players.csv", ((FileContentResult)result).FileDownloadName);
      Assert.Equal(fileContent, ((FileContentResult)result).FileContents);
      getService.VerifyAll();
      writer.VerifyAll();
    }

    [Fact]
    public async Task UploadStatsValidTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B), It.Is<StatsType>(i => i == StatsType.YTD)))
        .ReturnsAsync(6);
      var controller = new PlayerActionController(null, null, mergeService.Object);
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
      var controller = new PlayerActionController(null, null, mergeService.Object);
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.U, StatsType.PROJ));
    }

    [Fact]
    public async Task UploadStatsInvalidStatsTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      var controller = new PlayerActionController(null, null, mergeService.Object);
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.P, StatsType.UNKN));
    }


    [Fact]
    public async Task UploadStatsExceptionTest()
    {
      var mergeService = new Mock<IMergeStatsService>();
      mergeService
        .Setup(o => o.MergeStats(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P), It.Is<StatsType>(i => i == StatsType.YTD)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerActionController(null, null, mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadStats(PlayerType.P, StatsType.YTD));
    }
  }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
  public class PlayerActionControllerTest
  {
    [Fact]
    public async Task GetFile()
    {
      var fileContent = Encoding.ASCII.GetBytes("file-content");
      var getService = new Mock<IGetPlayerService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayer> { new BaseballPlayer() });
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
    public async Task UploadBattersTest()
    {
      var mergeService = new Mock<IMergeProjectionService>();
      mergeService.Setup(o => o.MergeProjection(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B))).ReturnsAsync(7);
      var controller = new PlayerActionController(null, null, mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      Assert.Equal(7, await controller.UploadBatterFile());
    }

    [Fact]
    public async Task UploadBattersExceptionTest()
    {
      var mergeService = new Mock<IMergeProjectionService>();
      mergeService
        .Setup(o => o.MergeProjection(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.B)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerActionController(null, null, mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadBatterFile());
    }

    [Fact]
    public async Task UploadPitchersTest()
    {
      var mergeService = new Mock<IMergeProjectionService>();
      mergeService.Setup(o => o.MergeProjection(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P))).ReturnsAsync(7);
      var controller = new PlayerActionController(null, null, mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      Assert.Equal(7, await controller.UploadPitcherFile());
    }

    [Fact]
    public async Task UploadPitchersExceptionTest()
    {
      var mergeService = new Mock<IMergeProjectionService>();
      mergeService
        .Setup(o => o.MergeProjection(It.IsAny<FormFileReader>(), It.Is<PlayerType>(i => i == PlayerType.P)))
        .ThrowsAsync(new Exception("Bad Request"));
      var controller = new PlayerActionController(null, null, mergeService.Object);
      var request = new Mock<HttpRequest>();
      var httpContext = new Mock<HttpContext>();
      httpContext.SetupGet(a => a.Request).Returns(request.Object);
      controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
      await Assert.ThrowsAsync<BadRequestException>(() => controller.UploadPitcherFile());
    }

    private static CsvBaseballPlayer BuildTestPlayer(int id) => new CsvBaseballPlayer { BhqId = id };

    private static List<CsvBaseballPlayer> BuildTestPlayerList(int id) => new List<CsvBaseballPlayer> { new CsvBaseballPlayer { BhqId = id } };
  }
}
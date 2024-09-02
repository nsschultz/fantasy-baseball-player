using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Controllers.V3;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Controllers.V3
{
  public class PlayerExportControllerTest
  {

    [Fact]
    public async Task GetFile()
    {
      var fileContent = Encoding.ASCII.GetBytes("file-content");
      var getService = new Mock<IGetPlayerService>();
      getService.Setup(o => o.GetPlayers()).ReturnsAsync([new()]);
      var writer = new Mock<ICsvFileWriterService>();
      writer.Setup(o => o.WriteCsvData(It.Is<List<BaseballPlayer>>(p => p.Count == 1))).Returns(fileContent);
      var controller = new PlayerExportController(getService.Object, writer.Object);
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
  }
}
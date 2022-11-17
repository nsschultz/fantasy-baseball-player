using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Controllers.V2.UnitTests
{
    public class PlayerExportControllerTest
    {
        [Fact]
        public async Task GetFile()
        {
            var fileContent = Encoding.ASCII.GetBytes("file-content");
            var getService = new Mock<IGetPlayersService>();
            getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<BaseballPlayer> { new BaseballPlayer() });
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

        private static CsvBaseballPlayer BuildTestPlayer(int id) => new CsvBaseballPlayer { BhqId = id };

        private static List<CsvBaseballPlayer> BuildTestPlayerList(int id) => new List<CsvBaseballPlayer> { new CsvBaseballPlayer { BhqId = id } };
    }
}
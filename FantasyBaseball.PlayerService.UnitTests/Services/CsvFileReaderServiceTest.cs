using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Maps.CsvMaps;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTets
{
  public class CsvFileReaderServiceTest
  {
    private static readonly List<string> BATTER_PROJ_RESULTS =
    [
      "HQID,MLBAMID,Player,Age,Bats,Team,Lg,Pos,LY5,LY10,LY15,LY20,LIMA,\"MM Code\",MM,ADP,\"Min ADP\",\"Max ADP\",DL,12$,15$,PA,AB,R,H,2B,3B,HR,RBI,BB,K,SB,CS,AVG,OBP,SLG,OPS,BB%,ct%,Eye,h%,PX,SPD,RSpd,G%,L%,F%,xBA,BA,RC/G,RAR,BPX",
      "6791,682928,\"Abrams, CJ\",23,L,WSH,NL,SS,6,6,6,6,D+,\"2535 AAB\",75,38.95,15,68,,23,27,646,613,99,153,30,5,15,69,32,122,53,9,.250,.287,.387,0.673,4%,0.80,0.26,29%,80,152,161,44%,19%,36%,.251,45%,4.0,-4.6,117",
      "2024-04-01 05:30:31"
    ];
    private static readonly List<string> BATTER_YTD_RESULTS =
    [
      "HQID,MLBAMID,Player,Age,Bats,Pos,Team,LG,ADP,\"Min ADP\",\"Max ADP\",AB,R,H,2B,3B,HR,RBI,BB,K,SB,CS,AVG,OBP,SLG,OPS,\"BB %\",Ct%,Eye,H%,HctX,xBA,\"GB %\",\"LD %\",\"FB %\",PX,xPX,SPD,RSPD,RCG,RAR,BPV,C,1B,2B,3B,SS,OF,DH",
      "6791,682928,\"Abrams, CJ\",23,L,SS,WSH,NL,38.95,15,68,28,5,8,,1,2,5,3,8,3,,.333,.407,.667,1.074,10.7%,66.7%,0.38,42.86%,125,.258,31.2%,18.8%,50.0%,198,118,140,93,11.46,4.50,91,,,,,6,,",
      "2024-04-01 05:30:31"
    ];
    private static readonly List<string> PITCHER_PROJ_RESULTS =
    [
      "HQID,MLBAMID,Player,Age,Throws,Tm,LG,LIMA,\"MM Code\",MM,ADP,\"Min ADP\",\"Max ADP\",DL,W,L,G,QS,SV,BS,HD,12$,15$,IP,H,ER,HR,BB,K,ERA,WHIP,BF/G,K9,K%,BB/9,BB%,Cmd,K-BB%,HR9,OOB,xERA,G%,L%,F%,H%,S%,RAR,BPX",
      "7179,671096,\"Abbott, Andrew\",24,L,CIN,NL,A+,\"1301 ADB\",6,285.71,141,424,,5,4,18,6,,,,-11,-7,94.0,89,45,14,38,103,4.31,1.35,21.8,9.9,26%,3.6,9%,2.7,16.6%,1.3,.324,4.68,27%,20%,53%,31%,72%,-3.7,98.0655",
      "2024-04-01 05:30:31"
    ];
    private static readonly List<string> PITCHER_YTD_RESULTS =
    [
      "HQID,MLBAMID,Player,Age,Throws,Team,LG,ADP,\"Min ADP\",\"Max ADP\",IP,G,GS,QS,W,L,SV,HD,BS,Sv%,H,ER,HR,K,BB,ERA,xERA,WHIP,BF/G,Vel,BB%,K/9,K%,SwK%,K-BB%,H%,S%,GB%,\"LD %\",\"FB %\",HR/9,HR/FB,xHR/FB,OBA,RAR,REff%,LI,BPX,Dom%,Dis%,R$,5x5$",
      "6034,650556,\"Abreu, Bryan\",26,R,HOU,AL,478.34,225,599,2.1,2,,,,1,,,1,0.00%,4,3,2,3,2,13.50,7.98,3.00,6,96.9,16%,13.5,25.0%,18.0%,0%,6%,75%,28%,14%,57%,9.0,0.5,1.8,400,-2.2,0.0%,2.1,6,,,,",
      "2024-04-01 05:30:31"
    ];

    [Fact]
    public async Task ReadCsvDataInvalidPlayerTypeTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(PITCHER_PROJ_RESULTS);
      await Assert.ThrowsAsync<HeaderValidationException>(() => new CsvFileReaderService().ReadCsvData(new BhqProjBattingsStatsMap(), fileReader.Object));
    }

    [Fact]
    public async Task ReadCsvDataInvalidStatsTypeTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(BATTER_PROJ_RESULTS);
      await Assert.ThrowsAsync<HeaderValidationException>(() => new CsvFileReaderService().ReadCsvData(new BhqYtdBattingsStatsMap(), fileReader.Object));
    }

    [Fact]
    public async Task ReadCsvDataValidBatterProjTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(BATTER_PROJ_RESULTS);
      var results = await new CsvFileReaderService().ReadCsvData(new BhqProjBattingsStatsMap(), fileReader.Object);
      Assert.Single(results);
      Assert.Equal(682928, results.First().MlbAmId);
    }

    [Fact]
    public async Task ReadCsvDataValidBatterYtdTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(BATTER_YTD_RESULTS);
      var results = await new CsvFileReaderService().ReadCsvData(new BhqYtdBattingsStatsMap(), fileReader.Object);
      Assert.Single(results);
      Assert.Equal(682928, results.First().MlbAmId);
    }

    [Fact]
    public async Task ReadCsvDataValidPitcherProjTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(PITCHER_PROJ_RESULTS);
      var results = await new CsvFileReaderService().ReadCsvData(new BhqProjPitchingStatsMap(), fileReader.Object);
      Assert.Single(results);
      Assert.Equal(671096, results.First().MlbAmId);
    }

    [Fact]
    public async Task ReadCsvDataValidPitcherYtdTest()
    {
      var fileReader = new Mock<IFileReader>();
      fileReader.Setup(o => o.ReadLines()).ReturnsAsync(PITCHER_YTD_RESULTS);
      var results = await new CsvFileReaderService().ReadCsvData(new BhqYtdPitchingStatsMap(), fileReader.Object);
      Assert.Single(results);
      Assert.Equal(650556, results.First().MlbAmId);
    }
  }
}
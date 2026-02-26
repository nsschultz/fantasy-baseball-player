using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Maps.CsvMaps;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services;

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
    "HQID,MLBAMID,Player,Age,Bats,Pos,Team,LG,C,1B,2B,3B,SS,OF,DH,PA,AB,R,H,2B,3B,HR,RBI,BB,K,SB,CS,AVG,OBP,SLG,OPS,\"BB %\",Ct%,Eye,H%,PX,xPX,HctX,SPD,RSPD,\"GB %\",\"LD %\",\"FB %\",xBA,RCG,RAR,BPV,12$,15$,GB,GBO,LD,LDO,FB,FBO,PAvRHP,PAvLHP,AVGvRHP,AVGvLHP,OBPvRHP,OBPvLHP,SLGvRHP,SLGvLHP,OPSvRHP,OPSvLHP,\"L31 C\",\"L31 1B\",\"L31 2B\",\"L31 3B\",\"L31 SS\",\"L31 OF\",\"L31 DH\",\"L31 AB\",\"L31 PA\",\"L31 R\",\"L31 H\",\"L31 2B\",\"L31 3B\",\"L31 HR\",\"L31 RBI\",\"L31 BB\",\"L31 K\",\"L31 SB\",\"L31 CS\",\"L31 AVG\",\"L31 OBP\",\"L31 SLG\",\"L31 OPS\",\"L31 BB%\",\"L31 CT%\",\"L31 Eye\",\"L31 H%\",\"L31 PX\",\"L31 xPX\",\"L31 HctX\",\"L31 Spd\",\"L31 RSpd\",\"L31 G%\",\"L31 L%\",\"L31 F%\",\"L31 xBA\",\"L31 RCG\",\"L31 RAR\",\"L31 BPV\",\"L31 GB\",\"L31 GBO\",\"L31 LD\",\"L31 LDO\",\"L31 FB\",\"L31 FBO\",\"L31 PAvRH\",\"L31 PAvLH\",\"L31 AVGvRH\",\"L31 AVGvLH\",\"L31 OBPvRH\",\"L31 OBPvLH\",\"L31 SLGvRH\",\"L31 SLGvLH\",\"L31 OPSvRH\",\"L31 OPSvLH\",\"L7 C\",\"L7 1B\",\"L7 2B\",\"L7 3B\",\"L7 SS\",\"L7 OF\",\"L7 DH\",\"L7 AB\",\"L7 PA\",\"L7 R\",\"L7 H\",\"L7 2B\",\"L7 3B\",\"L7 HR\",\"L7 RBI\",\"L7 BB\",\"L7 K\",\"L7 SB\",\"L7 CS\",\"L7 AVG\",\"L7 OBP\",\"L7 SLG\",\"L7 OPS\",\"L7 BB%\",\"L7 Ct%\",\"L7 Eye\",\"L7 H%\",\"L7 PX\",\"L7 xPX\",\"L7 HCtX\",\"L7 Spd\",\"L7 RSpd\",\"L7 G%\",\"L7 L%\",\"L7 F%\",\"L7 xBA\",\"L7 RCG\",\"L7 RAR\",\"L7 BPV\",\"L7 GB\",\"L7 GBO\",\"L7 LD\",\"L7 LDO\",\"L7 FB\",\"L7 FBO\",\"L7 PAvRH\",\"L7 PAvLH\",\"L7 AVGvRH\",\"L7 AVGvLH\",\"L7 OBPvRH\",\"L7 OBPvLH\",\"L7 SLGvRH\",\"L7 SLGvLH\",\"L7 OPSvRH\",\"L7 OPSvLH\"",
    "6791,682928,\"Abrams, CJ\",23,L,SS,WSH,NL,,,,,113,,,510,455,71,113,25,6,17,59,36,103,25,11,.248,.322,.442,0.764,7%,77%,0.35,28%,117,115,108,115,79,39%,20%,41%,.258,4.4,2.0,54,19,22,139,104,71,25,145,112,350,160,.231,.286,.315,.338,.438,.449,0.753,0.786,,,,,25,,,101,112,12,18,4,,2,11,6,23,10,1,.178,.250,.277,0.527,5.6%,77%,0.26,21%,65,76,85,102,137,44%,7%,48%,.195,2.19,-6.7,5,35,24,6,25,38,33,72,40,.125,.270,0.222,0.300,0.234,0.351,0.457,0.651,,,,,6,,,22,27,2,5,2,,,,2,7,5,1,.227,0.370,0.318,0.689,8%,68%,0.29,33%,90,81,37,108,169,40%,6%,53%,.180,3.45,-0.5,-4,6,4,1,,8,6,13,14,0.111,0.308,0.385,0.357,0.111,0.462,0.496,0.819",
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
    Assert.Equal(682928, results[0].MlbAmId);
  }

  [Fact]
  public async Task ReadCsvDataValidBatterYtdTest()
  {
    var fileReader = new Mock<IFileReader>();
    fileReader.Setup(o => o.ReadLines()).ReturnsAsync(BATTER_YTD_RESULTS);
    var results = await new CsvFileReaderService().ReadCsvData(new BhqYtdBattingsStatsMap(), fileReader.Object);
    Assert.Single(results);
    Assert.Equal(682928, results[0].MlbAmId);
    Assert.Equal(25, results[0].YearToDateBattingStats.Doubles);
    Assert.Equal(6, results[0].YearToDateBattingStats.Triples);
  }

  [Fact]
  public async Task ReadCsvDataValidPitcherProjTest()
  {
    var fileReader = new Mock<IFileReader>();
    fileReader.Setup(o => o.ReadLines()).ReturnsAsync(PITCHER_PROJ_RESULTS);
    var results = await new CsvFileReaderService().ReadCsvData(new BhqProjPitchingStatsMap(), fileReader.Object);
    Assert.Single(results);
    Assert.Equal(671096, results[0].MlbAmId);
  }

  [Fact]
  public async Task ReadCsvDataValidPitcherYtdTest()
  {
    var fileReader = new Mock<IFileReader>();
    fileReader.Setup(o => o.ReadLines()).ReturnsAsync(PITCHER_YTD_RESULTS);
    var results = await new CsvFileReaderService().ReadCsvData(new BhqYtdPitchingStatsMap(), fileReader.Object);
    Assert.Single(results);
    Assert.Equal(650556, results[0].MlbAmId);
  }
}
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.Database.Repositories.UnitTests
{
  public class TeamRepositoryTest : IDisposable
  {
    private PlayerContext _context;

    public TeamRepositoryTest() => _context = CreateContext().Result;

    [Fact] public async void GetAllTeamsTest() => Assert.Equal(31, (await new TeamRepository(_context).GetAllTeams()).Count);

    public void Dispose()
    {
      _context.Database.EnsureDeleted();
      _context.Dispose();
    }

    private async Task<PlayerContext> CreateContext()
    {
      var options = new DbContextOptionsBuilder<PlayerContext>()
        .UseInMemoryDatabase(databaseName: "GetTeamsTest")
        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;
      var context = new PlayerContext(options);
      context.Database.EnsureCreated();
      Assert.Equal(31, await context.Teams.CountAsync());
      return context;
    }
  }
}
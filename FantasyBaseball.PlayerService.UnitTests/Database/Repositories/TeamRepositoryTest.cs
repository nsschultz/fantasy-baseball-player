using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories
{
  public class TeamRepositoryTest : IDisposable
  {
    private PlayerContext _context;

    public TeamRepositoryTest() => _context = CreateContext().Result;

    [Fact] public async void GetAllTeamsTest() => Assert.Equal(31, (await new TeamRepository(_context).GetAllTeams()).Count);

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing) return;
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
using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories;

public class TeamRepositoryTest : IAsyncLifetime
{
    private PlayerContext _context = null!;

    public async Task InitializeAsync() => _context = await CreateContext();

    public async Task DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }

    [Fact] public async Task GetAllTeamsTest() => Assert.Equal(31, (await new TeamRepository(_context).GetAllTeams()).Count);

    private static async Task<PlayerContext> CreateContext()
    {
        var options = new DbContextOptionsBuilder<PlayerContext>()
          .UseInMemoryDatabase(databaseName: "GetTeamsTest")
          .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
          .Options;
        var context = new PlayerContext(options);
        await context.Database.EnsureCreatedAsync();
        Assert.Equal(31, await context.Teams.CountAsync());
        return context;
    }
}
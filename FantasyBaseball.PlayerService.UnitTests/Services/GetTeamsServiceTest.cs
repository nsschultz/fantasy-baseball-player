using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using LazyCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class GetTeamsServiceTest : IDisposable
    {
        private PlayerContext _context;

        public GetTeamsServiceTest() => _context = CreateContext().Result;

        [Fact]
        public async void GetTeamsCacheTest()
        {
            var services = new ServiceCollection();
            services.AddLazyCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IAppCache>();
            var service = new GetTeamsService(_context, memoryCache);
            Assert.Equal(31, (await service.GetTeams()).Count);
            Assert.Equal(31, (await service.GetTeams()).Count);
        }

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
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Services;
using FantasyBaseball.PlayerService.Services.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var BaseballSpecificOrigins = "_BaseballSpecificOrigins";
var SwaggerBasePath = "api/v2";
var SwaggerTitle = "FantasyBaseball.PlayerService";
var SwaggerVersion = "v2";

// Build the App Config
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration["ServiceUrls:PositionEndpoint"] = string.Format(
  builder.Configuration.GetValue<string>("ServiceUrls:PositionEndpoint"),
  builder.Configuration["POSITION_SERVICE_HOST"],
  builder.Configuration["POSITION_SERVICE_VERSION"]);
builder.Configuration["ServiceUrls:PositionHealthEndpoint"] = string.Format(
  builder.Configuration.GetValue<string>("ServiceUrls:PositionHealthEndpoint"),
  builder.Configuration["POSITION_SERVICE_HOST"]);
// Setup Cors
builder.Services.AddCors(options =>
{
  options.AddPolicy(
    name: BaseballSpecificOrigins,
    policy =>
    {
      policy.SetIsOriginAllowed(o =>
      {
        var host = new Uri(o).Host;
        return host == "localhost" || host.Contains("schultz.local");
      });
      policy.AllowAnyHeader();
      policy.AllowAnyMethod();
    });
});
// Setup Database
var connectionString = string.Format(
  builder.Configuration.GetConnectionString("PlayerDatabase"),
  builder.Configuration["PLAYER_DATABASE_HOST"],
  builder.Configuration["PLAYER_DATABASE"],
  builder.Configuration["PLAYER_DATABASE_USER"],
  builder.Configuration["PLAYER_DATABASE_PASSWORD"]);
builder.Services.AddDbContext<PlayerContext>(options => options.UseNpgsql(connectionString));
// Setup HealthChecks
builder.Services.AddHealthChecks()
  .AddDbContextCheck<PlayerContext>()
  .AddCheck<PositionHealthCheck>("Position");
// Setup Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Setup DI
builder.Services
  // Config
  .AddSingleton(builder.Configuration)
  // Context
  .AddScoped<IPlayerContext>(provider => provider.GetService<PlayerContext>())
  // Cache
  .AddLazyCache()
  // Repos
  .AddScoped<IPlayerRepository, PlayerRepository>()
  .AddScoped<ITeamRepository, TeamRepository>()
  // Services
  .AddSingleton<ICsvFileReaderService, CsvFileReaderService>()
  .AddSingleton<ICsvFileWriterService, CsvFileWriterService>()
  .AddSingleton<IGetPlayerEnumMapService, GetPlayerEnumMapService>()
  .AddScoped<IGetPlayersService, GetPlayersService>()
  .AddSingleton<IGetPositionService, GetPositionService>()
  .AddScoped<IGetTeamsService, GetTeamsService>()
  .AddScoped<IMergePlayerService, MergePlayerService>()
  .AddScoped<IMergeProjectionService, MergeProjectionService>()
  .AddScoped<IUpdatePlayerService, UpdatePlayerService>();
// Setup Swagger
builder.Services.AddSwaggerGen(o =>
{
  o.SwaggerDoc(SwaggerVersion, new OpenApiInfo { Title = SwaggerTitle, Version = SwaggerVersion });
  var currentAssembly = Assembly.GetExecutingAssembly();
  currentAssembly.GetReferencedAssemblies()
    .Union(new AssemblyName[] { currentAssembly.GetName() })
    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
    .Where(f => File.Exists(f))
    .ToList()
    .ForEach(f => o.IncludeXmlComments(f));
});
// Setup Controllers
builder.Services.AddControllers();

// Build the App
var app = builder.Build();
app.UseCors(BaseballSpecificOrigins);
app.UseHsts();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapHealthChecks("/api/health", new HealthCheckOptions { AllowCachingResponses = false });
app.UseSwagger(c => c.RouteTemplate = SwaggerBasePath + "/swagger/{documentName}/swagger.json");
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint($"/{SwaggerBasePath}/swagger/{SwaggerVersion}/swagger.json", $"{SwaggerTitle} - {SwaggerVersion}");
  c.RoutePrefix = $"{SwaggerBasePath}/swagger";
});
// Migrate Database on Startup
using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<PlayerContext>().Database.Migrate();
// Start the App
app.Run();
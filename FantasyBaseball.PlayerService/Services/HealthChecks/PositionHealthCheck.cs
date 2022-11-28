using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FantasyBaseball.PlayerService.Services.HealthChecks
{
    /// <summary>Health check to verify that the position service is healthy.</summary>
    public class PositionHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _config;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="config">The configuration for the application.</param>
        public PositionHealthCheck(IConfiguration config) => _config = config;

        /// <summary>Runs the health check, returning the status of the component being checked.</summary>
        /// <param name="context">A context object associated with the current execution.</param>
        /// <param name="cancellationToken">A CancellationToken that can be used to cancel the health check.</param>
        /// <returns>A Task that completes when the health check has finished, yielding the status of the component being checked.</returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var response = await new HttpClient().GetAsync(_config["ServiceUrls:PositionHealthEndpoint"], cancellationToken);
            return response.IsSuccessStatusCode
                ? HealthCheckResult.Healthy("A healthy result.")
                : new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result.");
        }
    }
}
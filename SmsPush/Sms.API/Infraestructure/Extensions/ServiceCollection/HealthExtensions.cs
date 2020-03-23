using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HealthExtensions
    {
        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            var selfLiveActive = configuration.GetValue<bool>("SelfLiveHealth:Active");
            if (selfLiveActive)
            {
                hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());
            }

            return services;
        }
    }
}

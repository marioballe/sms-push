using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Sms.API;
using System;


namespace Microsoft.AspNetCore.Builder
{
    public static class HealthExtensions
    {
        public static IApplicationBuilder UseCustomHealth(this IApplicationBuilder app, Sms.Core.Entities.AppSettings setting)
        {
            if (setting.SelfUiHealth.Active)
            {
                app.UseHealthChecks(setting.SelfUiHealth.Url, new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            }
            if (setting.SelfLiveHealth.Active)
            {
                app.UseHealthChecks(setting.SelfLiveHealth.Url, new HealthCheckOptions
                {
                    Predicate = r => r.Name.Contains("self")
                });
            }

            return app;
        }
    }
}
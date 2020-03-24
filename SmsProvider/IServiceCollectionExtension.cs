using Microsoft.Extensions.DependencyInjection;
using Sms.Provider;
using Sms.Provider.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSmsProviderService(this IServiceCollection services)
        {
            services.AddScoped<ISmsServiceProvider, SmsServiceProvider>();
            return services;
        }
    }
}
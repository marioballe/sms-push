using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace Sms.API.Infraestructure.Extensions.ServiceCollection
{
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class SwaggerExtensions
        {
            public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddSwaggerGen(options =>
                {
                    options.DescribeAllEnumsAsStrings();
                    options.SwaggerDoc("v1", new Info
                    {
                        Title = "SMS HTTP API",
                        Version = "v1",
                        Description = "The SMS Service HTTP API",
                        TermsOfService = "Terms Of Service"
                    });
                });

                return services;
            }
        }
    }
}

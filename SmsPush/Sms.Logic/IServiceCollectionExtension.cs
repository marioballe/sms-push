using Sms.Domain.Services;
using Sms.Logic.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSmsDomainService(this IServiceCollection services)
        {
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IOperationSmsProviderService, OperationSmsProviderService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IErrorsReportService, ErrorsReportService>();
            services.AddScoped<IExceptionsService, ExceptionsService>();
            services.AddScoped<IConsumerTokenService, ConsumerTokenService>();
            services.AddScoped<ISmsService, SmsService>();
            return services;
        }
    }
}

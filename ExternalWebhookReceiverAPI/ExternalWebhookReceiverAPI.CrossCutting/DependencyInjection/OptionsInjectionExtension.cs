using CommonSolution.Entities;
using CommonSolution.Entities.Logging;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection
{
    public static class OptionsInjectionExtension
    {
        public static IServiceCollection AddOptionsInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthorizationExternalWebhookOptions>(
                configuration.GetSection("AuthorizationExternalWebhook"));

            services.Configure<DefaultUserService>(
                configuration.GetSection("DefaultUser"));

            services.Configure<LoggingOptions>(
                configuration.GetSection("LoggingOptions")
);

            return services;
        }
    }
}

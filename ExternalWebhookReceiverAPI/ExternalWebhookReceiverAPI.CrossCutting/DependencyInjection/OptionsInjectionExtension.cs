using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection
{
    public static class OptionsInjectionExtension
    {
        public static IServiceCollection AddOptionsInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthorizationExternalWebhookOptions>(
                configuration.GetSection("AuthorizationExternalWebhook"));

            return services;
        }
    }
}

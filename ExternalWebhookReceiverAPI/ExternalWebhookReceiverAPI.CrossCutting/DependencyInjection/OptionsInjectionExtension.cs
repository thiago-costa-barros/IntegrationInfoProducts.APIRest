using CommonSolution.Utils.Helpers;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection
{
    public static class OptionsInjectionExtension
    {
        public static IServiceCollection AddOptionsInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommonOptions(configuration);
            
            services.Configure<AuthorizationExternalWebhookOptions>(
                configuration.GetSection("AuthorizationExternalWebhook"));

            return services;
        }
    }
}

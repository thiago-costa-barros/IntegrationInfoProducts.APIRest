using Azure.Core;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.API.Helpers
{
    public static class WebhookAuthHelper
    {
        public static string? GetHeaderKeyByIntegration(string integration, AuthorizationExternalWebhookOptions options)
        {
            return integration switch
            {
                "Hotmart" => options.Hotmart,
                "Udemy" => options.Udemy,
                _ => null
            };
        }
    }
}

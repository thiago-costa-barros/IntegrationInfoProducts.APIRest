using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.API.Helpers
{
    public static class HttpContextExtensions
    {
        public static string? GetWebhookAuthToken(this HttpContext httpContext, string integration)
        {
            var options = httpContext.RequestServices
                .GetRequiredService<IOptionsSnapshot<AuthorizationExternalWebhookOptions>>().Value;

            var expectedHeaderKey = WebhookAuthHelper.GetHeaderKeyByIntegration(integration, options);

            if (string.IsNullOrWhiteSpace(expectedHeaderKey) ||
                !httpContext.Request.Headers.TryGetValue(expectedHeaderKey, out var token) ||
                string.IsNullOrWhiteSpace(token))
            {
                return null;
            }

            return token.ToString();
        }
    }
}

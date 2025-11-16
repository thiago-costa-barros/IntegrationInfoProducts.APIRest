using ExternalWebhookReceiverAPI.API.Helpers;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using CommonSolution.Domain.Resources;
using CommonSolution.Domain.Abstractions.DTOs;

namespace ExternalWebhookReceiverAPI.API.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WebhookAuthAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _integration;

        public WebhookAuthAttribute(string integration)
        {
            _integration = integration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            foreach (var header in context.HttpContext.Request.Headers)
            {
                Debug.WriteLine($"Header: {header.Key} = {header.Value}");
            }
            var options = context.HttpContext.RequestServices
                .GetRequiredService<IOptionsSnapshot<AuthorizationExternalWebhookOptions>>().Value;

            // Obtém o nome do header esperado baseado no nome da integração
            var expectedHeaderName = WebhookAuthHelper.GetHeaderKeyByIntegration(_integration, options);
            var traceId = context.HttpContext?.TraceIdentifier;
            var apiMessage = new ApiMessage
            {
                Value = string.Format(ExternalWebhookReceiverMessages.AuthenticationHeaderNotFound),
                Details = new List<string> { string.Format(ExternalWebhookReceiverMessages.EXC0001, _integration) },
            };

            var response = new ApiErrorResponse
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                ErrorType = "Unauthorized",
                Message = apiMessage,
                TraceId = traceId,
                RequestTime = DateTime.UtcNow,
            };

            if (string.IsNullOrWhiteSpace(expectedHeaderName) ||
                !context.HttpContext.Request.Headers.TryGetValue(expectedHeaderName, out var headerValue) ||
                string.IsNullOrWhiteSpace(headerValue))
            {
                context.Result = new UnauthorizedObjectResult(response);
                return;
            }
        }
    }
}

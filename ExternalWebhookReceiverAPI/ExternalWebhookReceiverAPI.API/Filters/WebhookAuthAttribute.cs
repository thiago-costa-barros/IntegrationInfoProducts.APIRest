using ExternalWebhookReceiverAPI.API.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;

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

            var response = new ApiErrorResponse
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                ErrorType = "Unauthorized",
                Message = $"Header de autenticação não localizado.",
                RequestTime = DateTime.UtcNow,
                Details = $"Header de autenticação '{_integration}' é obrigatório."
            };

            if (string.IsNullOrWhiteSpace(expectedHeaderName) ||
                !context.HttpContext.Request.Headers.TryGetValue(expectedHeaderName, out var headerValue) ||
                string.IsNullOrWhiteSpace(headerValue))
            {
                context.Result = new UnauthorizedObjectResult(response);
                return;
            }


            // TODO: validar valor do header se necessário
        }
    }
}

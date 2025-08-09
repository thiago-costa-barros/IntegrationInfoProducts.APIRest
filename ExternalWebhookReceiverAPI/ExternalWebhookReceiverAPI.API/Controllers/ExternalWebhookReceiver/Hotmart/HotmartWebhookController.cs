using CommonSolution.Filters;
using CommonSolution.Helpers;
using ExternalWebhookReceiverAPI.API.Filters;
using ExternalWebhookReceiverAPI.API.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Options;
using CommonSolution.Entities.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using CommonSolution.Abstractions.DTOs;

namespace ExternalWebhookReceiverAPI.API.Controllers.ExternalWebhookReceiver.Hotmart
{
    [Route("api/external-webhook-receiver/hotmart/")]
    [ApiController]
    public class HotmartWebhookController : ControllerBase
    {
        private readonly IHotmartWebhookService _hotmartWebhookService;
        private readonly IOptionsSnapshot<AuthorizationExternalWebhookOptions> _authOptions;
        public HotmartWebhookController(IHotmartWebhookService hotmartWebhookService, IOptionsSnapshot<AuthorizationExternalWebhookOptions> authOptions)
        {
            _hotmartWebhookService = hotmartWebhookService;
            _authOptions = authOptions;
        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("webhook")]
        public async Task<IActionResult> HotmartWebhookRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            ExternalAuthenticationDTO? externalAuth = new ExternalAuthenticationDTO
            {
                AuthKey = token,
                Type = ExternalAuthenticationType.Hotmart
            };

            EnumHelper.TryParseEnum(payload.Event, out HotmartWebhookEventType eventType);

            var result = await _hotmartWebhookService.HandleWebhookService(payload, externalAuth);

            var message = MessageHelper.FormatFromEnum(
                enumValue: eventType,
                template: HotmartMessages.WebhookEventSuccess
            );

            ApiSuccessResponse response = ApiSuccessResponseFilter.CreateSuccessResponse(
                message, 
                JsonSerializer.SerializeToElement(result));

            return Ok(response);
        }
    }
}

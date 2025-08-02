using CommonSolution.DTOs;
using CommonSolution.Filters;
using CommonSolution.Helpers;
using ExternalWebhookReceiverAPI.API.Filters;
using ExternalWebhookReceiverAPI.API.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Options;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;

namespace ExternalWebhookReceiverAPI.API.Controllers.ExternalWebhookReceiver.Hotmart
{
    [Route("api/external-webhook-receiver/hotmart/")]
    [ApiController]
    public class HotmartPurchaseWebhookController : ControllerBase
    {
        private readonly IHotmartPurchaseWebhookService _hotmartPurchaseWebhookService;
        private readonly IOptionsSnapshot<AuthorizationExternalWebhookOptions> _authOptions;
        public HotmartPurchaseWebhookController(IHotmartPurchaseWebhookService hotmartPurchaseWebhookService, IOptionsSnapshot<AuthorizationExternalWebhookOptions> authOptions)
        {
            _hotmartPurchaseWebhookService = hotmartPurchaseWebhookService;
            _authOptions = authOptions;
        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-webhook")]
        public async Task<IActionResult> PurchaseWebhookRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            ExternalAuthenticationDTO? externalAuth = new ExternalAuthenticationDTO
            {
                AuthKey = token,
                Type = ExternalAuthenticationType.Hotmart
            };

            EnumHelper.TryParseEnum(payload.Event, out HotmartPurchaseEventType eventType);

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseWebhookService(payload, externalAuth);

            var message = MessageHelper.FormatFromEnum(
                enumValue: eventType,
                template: HotmartMessages.PurchaseEventSuccess
            );

            ApiSuccessResponse response = ApiSuccessResponseFilter.CreateSuccessResponse(
                message, 
                JsonSerializer.SerializeToElement(result));

            return Ok(response);
        }
    }
}

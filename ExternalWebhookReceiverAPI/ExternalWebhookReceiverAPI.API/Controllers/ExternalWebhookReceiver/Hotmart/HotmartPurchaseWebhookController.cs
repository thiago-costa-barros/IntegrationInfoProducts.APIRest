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
    [Route("api/external-webhook-receiver/hotmart/purchase-webhook/[controller]")]
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
        [Route("purchase-approved")]
        public async Task<IActionResult> PurchaseApprovedRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            ExternalAuthenticationDTO? externalAuth = new ExternalAuthenticationDTO
            {
                AuthKey = token,
                Type = ExternalAuthenticationType.Hotmart
            };

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseApprovedService(payload, externalAuth);

            var message = MessageHelper.FormatFromEnum(
                enumValue: HotmartPurchaseEventType.PURCHASE_APPROVED,
                template: HotmartMessages.PurchaseEventSuccess
            );

            ApiSuccessResponse response = ApiSuccessResponseFilter.CreateSuccessResponse(
                message, 
                JsonSerializer.SerializeToElement(result));

            return Ok(response);
        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-canceled")]
        public async Task<IActionResult> PurchaseCanceledRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseCanceledService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-complete")]
        public async Task<IActionResult> PurchaseCompleteRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseCompleteService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-billet-printed")]
        public async Task<IActionResult> PurchaseBilletPrintedRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseBilletPrintedService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-protest")]
        public async Task<IActionResult> PurchaseProtestRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseProtestService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-refunded")]
        public async Task<IActionResult> PurchaseRefundedRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseRefundedService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-chargeback")]
        public async Task<IActionResult> PurchaseChargebackRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseChargebackService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-expired")]
        public async Task<IActionResult> PurchaseExpiredRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseExpiredService(payload, token);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-delayed")]
        public async Task<IActionResult> PurchaseDelayedRoute([FromBody] HotmartWebhookDTO payload)
        {
            var token = HttpContext.GetWebhookAuthToken("Hotmart");
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException();

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseDelayedService(payload, token);
            return Ok(result);

        }
    }
}

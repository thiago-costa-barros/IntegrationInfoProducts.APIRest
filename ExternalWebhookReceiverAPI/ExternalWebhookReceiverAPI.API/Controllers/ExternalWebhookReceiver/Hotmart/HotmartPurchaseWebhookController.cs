using ExternalWebhookReceiverAPI.API.Filters;
using ExternalWebhookReceiverAPI.API.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

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
                throw new UnauthorizedAccessException("Token inválido ou ausente.");

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseApprovedService(payload);

            ApiSuccessResponse response = ApiSuccessResponseFilter.CreateSuccessResponse(
                "Compra aprovada com sucesso.", 
                JsonSerializer.SerializeToElement(new { result }));

            return Ok(response);
        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-canceled")]
        public async Task<IActionResult> PurchaseCanceledRoute([FromBody] HotmartWebhookDTO payload)
        {


            var result = await _hotmartPurchaseWebhookService.HandlePurchaseCanceledService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-complete")]
        public async Task<IActionResult> PurchaseCompleteRoute([FromBody] HotmartWebhookDTO payload)
        {


            var result = await _hotmartPurchaseWebhookService.HandlePurchaseCompleteService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-billet-printed")]
        public async Task<IActionResult> PurchaseBilletPrintedRoute([FromBody] HotmartWebhookDTO payload)
        {


            var result = await _hotmartPurchaseWebhookService.HandlePurchaseBilletPrintedService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-protest")]
        public async Task<IActionResult> PurchaseProtestRoute([FromBody] HotmartWebhookDTO payload)
        {

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseProtestService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-refunded")]
        public async Task<IActionResult> PurchaseRefundedRoute([FromBody] HotmartWebhookDTO payload)
        {

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseRefundedService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-chargeback")]
        public async Task<IActionResult> PurchaseChargebackRoute([FromBody] HotmartWebhookDTO payload)
        {


            var result = await _hotmartPurchaseWebhookService.HandlePurchaseChargebackService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-expired")]
        public async Task<IActionResult> PurchaseExpiredRoute([FromBody] HotmartWebhookDTO payload)
        {


            var result = await _hotmartPurchaseWebhookService.HandlePurchaseExpiredService(payload);
            return Ok(result);

        }

        [WebhookAuth("Hotmart")]
        [HttpPost]
        [Route("purchase-delayed")]
        public async Task<IActionResult> PurchaseDelayedRoute([FromBody] HotmartWebhookDTO payload)
        {

            var result = await _hotmartPurchaseWebhookService.HandlePurchaseDelayedService(payload);
            return Ok(result);

        }
    }
}

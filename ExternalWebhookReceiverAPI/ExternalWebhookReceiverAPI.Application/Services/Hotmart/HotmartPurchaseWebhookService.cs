using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartPurchaseWebhookService : IHotmartPurchaseWebhookService
    {
        public async Task<HotmartWebhookDTO> HandlePurchaseApprovedService(HotmartWebhookDTO payload, string token)
        {
            return await Task.FromResult(payload);
        }

        public Task<HotmartWebhookDTO> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCanceledService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseChargebackService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCompleteService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseDelayedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseExpiredService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseProtestService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseRefundedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }
    }
}
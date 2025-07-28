using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartPurchaseWebhookService : IHotmartPurchaseWebhookService
    {
        public async Task<HotmartWebhookDTO> HandlePurchaseApprovedService(HotmartWebhookDTO payload)
        {
            return await Task.FromResult(payload);
        }

        public Task<HotmartWebhookDTO> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCanceledService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseChargebackService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCompleteService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseDelayedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseExpiredService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseProtestService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseRefundedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }
    }
}
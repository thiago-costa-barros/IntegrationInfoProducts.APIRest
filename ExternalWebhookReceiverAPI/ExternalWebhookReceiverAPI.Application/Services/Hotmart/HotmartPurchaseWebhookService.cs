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
        public async Task<string> HandlePurchaseApprovedService(HotmartWebhookDTO payload)
        {
            return await Task.FromResult($"Evento recebido com sucesso. Payload: {payload}");
        }

        public async Task<string> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseCanceledService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseChargebackService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public Task<string> HandlePurchaseCompleteService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseDelayedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseExpiredService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseProtestService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }

        public async Task<string> HandlePurchaseRefundedService(HotmartWebhookDTO payload)
        {
            throw new NotImplementedException();
        }
    }
}
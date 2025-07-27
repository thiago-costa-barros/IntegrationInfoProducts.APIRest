using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart
{
    public interface IHotmartPurchaseWebhookService
    {
        Task<string> HandlePurchaseApprovedService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseCanceledService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseCompleteService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseProtestService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseRefundedService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseChargebackService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseExpiredService(HotmartWebhookDTO payload);
        Task<string> HandlePurchaseDelayedService(HotmartWebhookDTO payload);

    }
}

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
        Task<HotmartWebhookDTO> HandlePurchaseApprovedService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseCanceledService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseCompleteService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseProtestService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseRefundedService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseChargebackService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseExpiredService(HotmartWebhookDTO payload);
        Task<HotmartWebhookDTO> HandlePurchaseDelayedService(HotmartWebhookDTO payload);

    }
}

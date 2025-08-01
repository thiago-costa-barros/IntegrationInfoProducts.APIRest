using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart
{
    public interface IHotmartPurchaseWebhookService
    {
        Task<HotmartWebhookDTO> HandlePurchaseApprovedService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseCanceledService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseCompleteService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseProtestService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseRefundedService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseChargebackService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseExpiredService(HotmartWebhookDTO payload, string token);
        Task<HotmartWebhookDTO> HandlePurchaseDelayedService(HotmartWebhookDTO payload, string token);

    }
}

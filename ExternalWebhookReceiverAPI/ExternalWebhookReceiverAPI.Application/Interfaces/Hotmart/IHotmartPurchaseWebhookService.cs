using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart
{
    public interface IHotmartPurchaseWebhookService
    {
        Task<HotmartWebhookDTO> HandlePurchaseWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth);

    }
}

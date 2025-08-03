using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart
{
    public interface IHotmartWebhookService
    {
        Task<HotmartWebhookDTO> HandleWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth);

    }
}

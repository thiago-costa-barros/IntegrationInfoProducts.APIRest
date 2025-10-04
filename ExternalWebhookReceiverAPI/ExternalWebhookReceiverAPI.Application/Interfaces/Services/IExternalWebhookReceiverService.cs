using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    public interface IExternalWebhookReceiverService
    {
        Task ValidationExternalWebhookReceiverIdentifier(string identifier, BusinessUnit businessUnit);
        Task InsertExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver);
    }
}

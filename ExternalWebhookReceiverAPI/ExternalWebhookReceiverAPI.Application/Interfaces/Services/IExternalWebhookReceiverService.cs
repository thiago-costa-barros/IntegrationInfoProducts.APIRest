using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    public interface IExternalWebhookReceiverService
    {
        Task ValidationExternalWebhookReceiverIdentifier(string identifier, BusinessUnit businessUnit);
        Task<ExternalWebhookReceiver> InsertExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver);
        Task InsertExternalWebhookReceiverStatusHistoric(ExternalWebhookReceiverStatusHistoric externalWebhookReceiverStatusHistoric);
    }
}

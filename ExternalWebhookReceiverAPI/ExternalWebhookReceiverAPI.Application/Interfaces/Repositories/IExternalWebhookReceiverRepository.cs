using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to ExternalWebhookReceiver.
    /// Responsible for delegating data access to DAO and mapping results to domain models.
    /// </summary>
    public interface IExternalWebhookReceiverRepository
    {
        Task<ExternalWebhookReceiver> InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
        Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(string? identifier, BusinessUnit businessUnit);
        Task InsertExternalWebhookReceiverStatusHistoric(ExternalWebhookReceiverStatusHistoric externalWebhookReceiverStatusHistoric);
    }
}

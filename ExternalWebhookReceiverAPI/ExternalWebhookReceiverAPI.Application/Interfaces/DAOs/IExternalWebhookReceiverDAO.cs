using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the ExternalWebhookReceiver entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IExternalWebhookReceiverDAO
    {
        Task<ExternalWebhookReceiver> InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
        Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(string identifier, BusinessUnit businessUnit);
        Task InsertExternalWebhookReceiverStatusHistoric(ExternalWebhookReceiverStatusHistoric externalWebhookReceiverStatusHistoric);
    }
}

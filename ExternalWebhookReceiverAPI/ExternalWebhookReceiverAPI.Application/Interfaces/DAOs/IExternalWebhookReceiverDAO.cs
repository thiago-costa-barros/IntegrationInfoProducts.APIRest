using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the ExternalWebhookReceiver entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IExternalWebhookReceiverDAO
    {
        Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
        Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(string identifier, BusinessUnit businessUnit);
    }
}

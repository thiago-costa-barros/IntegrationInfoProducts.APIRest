using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to external authentication.
    /// Responsible for delegating data access to DAO and mapping results to domain models.
    /// </summary>
    public interface IExternalWebhookReceiverRepository
    {
        /// <summary>
        /// Saves an ExternalWebhookReceiver entity to the database.
        /// </summary>
        Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
    }
}

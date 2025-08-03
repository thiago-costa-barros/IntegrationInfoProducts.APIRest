using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the ExternalAuthentication entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IExternalWebhookReceiverDAO
    {
        /// <summary>
        /// Saves an ExternalWebhookReceiver entity to the database.
        /// </summary>
        /// <param name="externalWebhookReceiver">The entity to save.</param>
        /// <param name="defaultUserId">The ID of the user performing the operation. It's define in config.</param>
        Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
    }
}

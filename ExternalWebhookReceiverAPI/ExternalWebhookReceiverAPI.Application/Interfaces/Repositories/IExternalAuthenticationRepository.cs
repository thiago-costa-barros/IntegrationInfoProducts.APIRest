using CommonSolution.Domain.Entities.Common.Enums;
using CommonSolution.Domain.Entities.IntegrationSchema;
using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to external authentication.
    /// Responsible for delegating data access to DAO and mapping results to domain models.
    /// </summary>
    public interface IExternalAuthenticationRepository
    {
        /// <summary>
        /// Retrieves the ExternalAuthentication entity associated with the given external authentication token.
        /// Delegates query execution to the data access layer.
        /// </summary>
        /// <returns>The ExternalAuthentication entity associated with the token, or null if not found.</returns>
        Task<ExternalAuthentication?> GetExternalAuthenticationByTokenAsync(string? externalAuth, ExternalAuthenticationType externalAuthenticationType);
    }

}

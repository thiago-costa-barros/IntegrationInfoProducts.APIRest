using CommonSolution.Domain.Entities.Common.Enums;
using CommonSolution.Domain.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the ExternalAuthentication entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IExternalAuthenticationDAO
    {
        /// <summary>
        /// Fetches the ExternalAuthentication entity linked to the provided external authentication token.
        /// Executes the query using EF Core based on AuthType and AuthKey.
        /// </summary>
        /// <returns>The ExternalAuthentication entity if a match is found; otherwise, null.</returns>
        Task<ExternalAuthentication?> GetExternalAuthenticationByToken(string externalAuth, ExternalAuthenticationType type);
    }
}
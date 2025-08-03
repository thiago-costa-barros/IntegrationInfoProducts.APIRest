using CommonSolution.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    /// <summary>
    /// Defines the contract for service-level logic related to external authentication.
    /// Responsible for applying business rules and retrieving associated company data.
    /// </summary>
    public interface IExternalAuthenticationService
    {
        /// <summary>
        /// Resolves and returns the company associated with the provided authentication token.
        /// Applies validation and business rules before returning the result.
        /// </summary>
        /// <param name="token">The external authentication token (e.g., from Hotmart, Udemy).</param>
        /// <returns>The company associated with the token, or null if invalid.</returns>
        Task<Company?> GetCompanyFromTokenAsync(string token);
    }
}

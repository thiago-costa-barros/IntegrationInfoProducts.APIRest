using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    /// <summary>
    /// Defines the contract for service-level logic related to BusinessUnit.
    /// Responsible for applying business rules and retrieving associated BusinessUnit data.
    /// </summary>
    public interface IBusinessUnitService
    {
        /// <summary>
        /// Resolves and returns the BusinessUnit associated with the provided Id.
        /// Applies validation and business rules before returning the result.
        /// </summary>
        /// <param name="taxNumber">The BusinessUnitId.</param>
        /// <returns>The BusinessUnit associated with the Id, or null if invalid.</returns>
        Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId);
    }
}

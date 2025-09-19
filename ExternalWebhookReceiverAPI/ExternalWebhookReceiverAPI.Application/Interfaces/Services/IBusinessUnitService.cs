using CommonSolution.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    /// <summary>
    /// Defines the contract for service-level logic related to BusinessUnit.
    /// Responsible for applying business rules and retrieving associated BusinessUnit data.
    /// </summary>
    public interface IBusinessUnitService
    {
        /// <summary>
        /// Resolves and returns the BusinessUnit associated with the provided TaxNumber.
        /// Applies validation and business rules before returning the result.
        /// </summary>
        /// <param name="taxNumber">The BusinessUnitTaxNumber.</param>
        /// <returns>The BusinessUnit associated with the TaxNumber, or null if invalid.</returns>
        Task<BusinessUnit?> GetBusinessUnitByTaxNumberAsync(string? taxNumber);
    }
}

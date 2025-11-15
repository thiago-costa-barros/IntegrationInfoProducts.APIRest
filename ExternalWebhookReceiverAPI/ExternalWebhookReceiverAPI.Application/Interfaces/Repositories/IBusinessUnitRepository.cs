using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to BusinessUnit.
    /// Responsible for delegating data access to DAO and mapping results to domain models.
    /// </summary>
    public interface IBusinessUnitRepository
    {
        /// <summary>
        /// Retrieves the BusinessUnit entity associated with the given BusinessUnit Id.
        /// Delegates query execution to the data access layer.
        /// </summary>
        /// <returns>The BusinessUnit entity associated with the Id, or null if not found.</returns>
        Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId);
    }
}

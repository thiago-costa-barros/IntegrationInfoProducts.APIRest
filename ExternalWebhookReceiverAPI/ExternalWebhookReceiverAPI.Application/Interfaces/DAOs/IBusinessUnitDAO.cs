using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the BusinessUnit entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IBusinessUnitDAO
    {
        /// <summary>
        /// Fetches the BusinessUnit entity linked to the provided BusinessUnit.
        /// Executes the query using EF Core based on Id.
        /// </summary>
        /// <returns>The BusinessUnit entity if a match is found; otherwise, null.</returns>
        Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId);
    }
}

using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class BusinessUnitRepository : IBusinessUnitRepository
    {
        private readonly IBusinessUnitDAO _businessUnitDAO;
        private readonly bool useCache;
        private readonly bool updateRealtimeCache;

        public BusinessUnitRepository(IBusinessUnitDAO businessUnitDAO, IOptions<AppSettings> config)
        {
            _businessUnitDAO = businessUnitDAO;
            useCache = config.Value.UseCache;
            updateRealtimeCache = config.Value.UpdateRealtimeCache;
        }
        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId)
        {
            BusinessUnit? businessUnit = new BusinessUnit();

            if (useCache)
            {
                if (updateRealtimeCache)
                {
                    // Implement logic to update cache in real-time if needed
                }
                else
                {
                    // Implement logic to retrieve from cache if available
                }
                return businessUnit;
            }
            else
            {
                businessUnit = await _businessUnitDAO.GetBusinessUnitById(businessUnitId);
            }
            return businessUnit;
        }
    }
}

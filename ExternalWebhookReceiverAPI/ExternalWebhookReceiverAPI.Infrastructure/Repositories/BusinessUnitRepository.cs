using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories
{
    public class BusinessUnitRepository : IBusinessUnitRepository
    {
        private readonly IBusinessUnitDAO _businessUnitDAO;
        public BusinessUnitRepository(IBusinessUnitDAO businessUnitDAO)
        {
            _businessUnitDAO = businessUnitDAO;
        }
        public async Task<BusinessUnit?> GetBusinessUnitByTaxNumberAsync(string? taxNumber)
        {
            BusinessUnit? businessUnit = await _businessUnitDAO.GetBusinessUnitByTaxNumberAsync(taxNumber);

            return businessUnit;
        }
    }
}

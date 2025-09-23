using CommonSolution.CrossCutting;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    public class BusinessUnitDAO : IBusinessUnitDAO
    {
        private readonly ApplicationDbContext _context;
        public BusinessUnitDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId)
        {
            throw new NotImplementedException();
        }
    }
}

using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using Microsoft.EntityFrameworkCore;

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
            BusinessUnit? result = await _context.Set<BusinessUnit>()
                .FirstOrDefaultAsync(x => 
                x.BusinessUnitId == businessUnitId 
                && x.DeletionDate == null);

            return result;
        }
    }
}

using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    /// <summary>
    /// DAO implementation for retrieving Company data via external authentication token.
    /// Uses EF Core to query the ExternalAuthentication table.
    /// </summary>
    public class ExternalAuthenticationDAO : IExternalAuthenticationDAO
    {
        private readonly ApplicationDbContext _context;
        public ExternalAuthenticationDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> GetCompanyByTokenAsync(string externalAuth, ExternalAuthenticationType type)
        {
            var result = await _context.ExternalAuthentication
                .AsNoTracking()
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x =>
                    x.AuthKey == externalAuth &&
                    x.AuthType == type &&
                    x.DeletionDate == null);

            return result?.Company;
        }
    }
}

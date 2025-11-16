using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.Domain.Entities.Common.Enums;
using CommonSolution.Domain.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    /// <summary>
    /// DAO implementation for retrieving BusinessUnit data via external authentication token.
    /// Uses EF Core to query the ExternalAuthentication table.
    /// </summary>
    public class ExternalAuthenticationDAO : IExternalAuthenticationDAO
    {
        private readonly ApplicationDbContext _context;
        public ExternalAuthenticationDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExternalAuthentication?> GetExternalAuthenticationByToken(string externalAuth, ExternalAuthenticationType type)
        {
            var result = await _context.Set<ExternalAuthentication>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.AuthKey == externalAuth &&
                    x.AuthType == type &&
                    x.DeletionDate == null);

            return result;
        }
    }
}

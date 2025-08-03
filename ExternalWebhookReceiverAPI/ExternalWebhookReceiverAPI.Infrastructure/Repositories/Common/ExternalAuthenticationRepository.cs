using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalAuthenticationRepository : IExternalAuthenticationRepository
    {
        private readonly IExternalAuthenticationDAO _externalAuthenticationDAO;
        public ExternalAuthenticationRepository(IExternalAuthenticationDAO externalAuthenticationDAO)
        {
            _externalAuthenticationDAO = externalAuthenticationDAO;
        }
        public async Task<Company?> GetCompanyByTokenAsync(ExternalAuthenticationDTO externalAuth)
        {
            return await _externalAuthenticationDAO.GetCompanyByTokenAsync(externalAuth);
        }
    }
}

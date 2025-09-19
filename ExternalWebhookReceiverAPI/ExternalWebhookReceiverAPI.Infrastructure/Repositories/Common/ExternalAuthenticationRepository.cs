using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.Common.Enums;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using CommonSolution.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalAuthenticationRepository : IExternalAuthenticationRepository
    {
        private readonly IExternalAuthenticationDAO _externalAuthenticationDAO;
        public ExternalAuthenticationRepository(IExternalAuthenticationDAO externalAuthenticationDAO)
        {
            _externalAuthenticationDAO = externalAuthenticationDAO;
        }
        public async Task<ExternalAuthentication?> GetExternalAuthenticationByTokenAsync(string? externalAuth, ExternalAuthenticationType externalAuthenticationType)
        {
            return await _externalAuthenticationDAO.GetExternalAuthenticationByTokenAsync(externalAuth, externalAuthenticationType);
        }
    }
}

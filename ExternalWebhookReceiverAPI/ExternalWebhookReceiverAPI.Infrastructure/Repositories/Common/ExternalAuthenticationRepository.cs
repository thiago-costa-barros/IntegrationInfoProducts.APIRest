using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using CommonSolution.Domain.Entities.IntegrationSchema;
using CommonSolution.Domain.Entities.Common.Enums;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalAuthenticationRepository : IExternalAuthenticationRepository
    {
        private readonly IExternalAuthenticationDAO _externalAuthenticationDAO;
        public ExternalAuthenticationRepository(IExternalAuthenticationDAO externalAuthenticationDAO)
        {
            _externalAuthenticationDAO = externalAuthenticationDAO;
        }
        public async Task<ExternalAuthentication?> GetExternalAuthenticationByToken(string? externalAuth, ExternalAuthenticationType externalAuthenticationType)
        {
            return await _externalAuthenticationDAO.GetExternalAuthenticationByToken(externalAuth, externalAuthenticationType);
        }
    }
}

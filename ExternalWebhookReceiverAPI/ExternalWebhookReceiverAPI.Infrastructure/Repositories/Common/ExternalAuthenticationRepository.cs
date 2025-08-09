using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Interfaces.Repositories;
using CommonSolution.Interfaces.DAOs;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalAuthenticationRepository : IExternalAuthenticationRepository
    {
        private readonly IExternalAuthenticationDAO _externalAuthenticationDAO;
        public ExternalAuthenticationRepository(IExternalAuthenticationDAO externalAuthenticationDAO)
        {
            _externalAuthenticationDAO = externalAuthenticationDAO;
        }
        public async Task<Company?> GetCompanyByTokenAsync(string? externalAuth, ExternalAuthenticationType externalAuthenticationType)
        {
            return await _externalAuthenticationDAO.GetCompanyByTokenAsync(externalAuth, externalAuthenticationType);
        }
    }
}

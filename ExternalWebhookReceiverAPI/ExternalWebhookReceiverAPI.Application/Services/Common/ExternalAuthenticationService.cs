using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    public class ExternalAuthenticationService : IExternalAuthenticationService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExternalAuthenticationService(IExternalAuthenticationRepository externalAuthRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _externalAuthRepository = externalAuthRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ExternalAuthentication?> GetExternalAuthenticationFromTokenAsync(ExternalAuthenticationDTO externalAuthenticationDTO)
        {
            ExternalAuthentication? externalAuthentication = await _externalAuthRepository.GetExternalAuthenticationByTokenAsync(externalAuthenticationDTO.AuthKey, externalAuthenticationDTO.Type);
            if (externalAuthentication == null)
                throw new UnauthorizedAccessException(ExceptionMessages.InvalidCredentials);

            return externalAuthentication;
        }
    }
}

using CommonSolution.Domain.Entities.IntegrationSchema;
using CommonSolution.Domain.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    public class ExternalAuthenticationService : IExternalAuthenticationService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        public ExternalAuthenticationService(IExternalAuthenticationRepository externalAuthRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _externalAuthRepository = externalAuthRepository;
        }
        public async Task<ExternalAuthentication?> GetExternalAuthenticationByToken(ExternalAuthenticationDTO externalAuthenticationDTO)
        {
            ExternalAuthentication? externalAuthentication = await _externalAuthRepository.GetExternalAuthenticationByToken(externalAuthenticationDTO.AuthKey, externalAuthenticationDTO.Type);
            if (externalAuthentication == null)
                throw new UnauthorizedAccessException(ExceptionMessages.InvalidCredentials);

            return externalAuthentication;
        }
    }
}

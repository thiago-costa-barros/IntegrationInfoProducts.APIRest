using CommonSolution.Entities.CoreSchema;
using CommonSolution.Interfaces.Repositories;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
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
        public async Task<Company?> GetCompanyFromTokenAsync(ExternalAuthenticationDTO externalAuthenticationDTO)
        {
            Company? company = await _externalAuthRepository.GetCompanyByTokenAsync(externalAuthenticationDTO.AuthKey, externalAuthenticationDTO.Type);
            if (company == null)
                throw new UnauthorizedAccessException(ExceptionMessages.EXC0001);
            _httpContextAccessor.HttpContext?.Items.TryAdd("CompanyId", company.CompanyId);

            return company;
        }
    }
}

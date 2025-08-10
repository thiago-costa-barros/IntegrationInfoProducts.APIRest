using CommonSolution.Entities.CoreSchema;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using CommonSolution.Entities.Common.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using CommonSolution.Entities.Common;
using CommonSolution.Interfaces.Repositories;
using CommonSolution.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartWebhookService : IHotmartWebhookService
    {
        private readonly IExternalAuthenticationService _externalAuthService;
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        private readonly IValidator<HotmartWebhookDTO> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HotmartWebhookService(IExternalAuthenticationService externalAuthService,
            IOptions<DefaultUserService> defaultUser,
            IExternalWebhookReceiverRepository externalWebhookReceiverRepository,
            IValidator<HotmartWebhookDTO> validator,
            IHttpContextAccessor httpContextAccessor)
        {
            _externalAuthService = externalAuthService;
            _defaultUser = defaultUser;
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
            _validator = validator;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<HotmartWebhookDTO> HandleWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            var validationResult = await _validator.ValidateAsync(payload);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Company? company = await _externalAuthService.GetCompanyFromTokenAsync(externalAuth);

            await ValidationHotmartWebhook(payload, company);

            DefaultUserService defaultUser = _defaultUser.Value;
            ExternalWebhookReceiver externalWebhookReceiver = HotmartWebhookMapper.ToExternalWebhookReceiver(
                dto: payload,
                company: company,
                sourceType: ExternalWebhookReceiverSourceType.Hotmart,
                defaultUser: defaultUser
            );

            await _externalWebhookReceiverRepository.InsertExternalWebhookAsync(externalWebhookReceiver);

            return await Task.FromResult(payload);
        }

        private async Task ValidationHotmartWebhook(HotmartWebhookDTO payload, Company company)
        {
            ExternalWebhookReceiver? existExternalWebhookReceiver = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByIdenitifierAndCompanyId(payload.Id, company);
            if (existExternalWebhookReceiver != null)
                throw new ArgumentException(string.Format(HotmartMessages.EXC0002, payload.Id));
        }
    }
}
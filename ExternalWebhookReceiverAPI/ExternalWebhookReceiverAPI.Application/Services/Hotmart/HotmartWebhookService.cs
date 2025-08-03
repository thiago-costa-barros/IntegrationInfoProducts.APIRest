using CommonSolution.Entities;
using CommonSolution.Entities.CoreSchema;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartWebhookService : IHotmartWebhookService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        private readonly IValidator<HotmartWebhookDTO> _validator;
        public HotmartWebhookService(IExternalAuthenticationRepository externalAuthRepository, 
            IOptions<DefaultUserService> defaultUser, 
            IExternalWebhookReceiverRepository externalWebhookReceiverRepository,
            IValidator<HotmartWebhookDTO> validator)
        {
            _externalAuthRepository = externalAuthRepository;
            _defaultUser = defaultUser;
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
            _validator = validator;
        }
        public async Task<HotmartWebhookDTO> HandleWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            var validationResult = await _validator.ValidateAsync(payload);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Company? company = await _externalAuthRepository.GetCompanyByTokenAsync(externalAuth);
            if (company == null)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.EXC0001);
            }

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
            //if (string.IsNullOrEmpty(payload.Id))
            //    throw new ArgumentException(string.Format(HotmartMessages.EXC0001));

            ExternalWebhookReceiver? existExternalWebhookReceiver = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByIdenitifierAndCompanyId(payload,company);
            if (existExternalWebhookReceiver != null)
                throw new ArgumentException(string.Format(HotmartMessages.EXC0002, payload.Id));
        }
    }
}
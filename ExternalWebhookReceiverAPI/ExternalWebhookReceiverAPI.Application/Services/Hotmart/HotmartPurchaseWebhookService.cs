using CommonSolution.Entities;
using CommonSolution.Entities.CoreSchema;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using Microsoft.Extensions.Options;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartPurchaseWebhookService : IHotmartPurchaseWebhookService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        public HotmartPurchaseWebhookService(IExternalAuthenticationRepository externalAuthRepository, IOptions<DefaultUserService> defaultUser, IExternalWebhookReceiverRepository externalWebhookReceiverRepository)
        {
            _externalAuthRepository = externalAuthRepository;
            _defaultUser = defaultUser;
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
        }
        public async Task<HotmartWebhookDTO> HandlePurchaseWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            Company? company = await _externalAuthRepository.GetCompanyByTokenAsync(externalAuth);
            if (company == null)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.EXC0001);
            }

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
    }
}
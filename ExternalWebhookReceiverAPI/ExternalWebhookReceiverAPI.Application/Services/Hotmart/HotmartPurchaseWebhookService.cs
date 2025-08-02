using CommonSolution.Entities.CoreSchema;
using CommonSolution.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Common;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartPurchaseWebhookService : IHotmartPurchaseWebhookService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        public HotmartPurchaseWebhookService(IExternalAuthenticationRepository externalAuthRepository)
        {
            _externalAuthRepository = externalAuthRepository;
        }
        public async Task<HotmartWebhookDTO> HandlePurchaseWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            Company? company = await _externalAuthRepository.GetCompanyByTokenAsync(externalAuth);
            if (company == null)
            {
                throw new UnauthorizedAccessException(MessageHelper.GetExceptionMessage("EXC0001"));
            }

            ExternalWebhookReceiver externalWebhookReceiver = HotmartWebhookMapper.ToExternalWebhookReceiver(
                dto: payload,
                company: company,
                sourceType: ExternalWebhookReceiverSourceType.Hotmart
            );

            return await Task.FromResult(payload);
        }
    }
}
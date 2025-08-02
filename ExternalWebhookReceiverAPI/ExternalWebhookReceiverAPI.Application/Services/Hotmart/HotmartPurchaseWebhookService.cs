using CommonSolution.Entities.CoreSchema;
using CommonSolution.Helpers;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Common;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartPurchaseWebhookService : IHotmartPurchaseWebhookService
    {
        private readonly IExternalAuthenticationRepository _externalAuthRepository;
        public HotmartPurchaseWebhookService(IExternalAuthenticationRepository externalAuthRepository)
        {
            _externalAuthRepository = externalAuthRepository;
        }
        public async Task<HotmartWebhookDTO> HandlePurchaseApprovedService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            Company? company = await _externalAuthRepository.GetCompanyByTokenAsync(externalAuth);
            if (company == null)
            {
                throw new UnauthorizedAccessException(MessageHelper.GetExceptionMessage("EXC0001"));
            }

            return await Task.FromResult(payload);
        }

        public Task<HotmartWebhookDTO> HandlePurchaseBilletPrintedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCanceledService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseChargebackService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseCompleteService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseDelayedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseExpiredService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseProtestService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }

        public Task<HotmartWebhookDTO> HandlePurchaseRefundedService(HotmartWebhookDTO payload, string token)
        {
            throw new NotImplementedException();
        }
    }
}
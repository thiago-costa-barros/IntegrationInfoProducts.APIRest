using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using CommonSolution.Entities.Common.Enums;
using FluentValidation;
using Microsoft.Extensions.Options;
using CommonSolution.Entities.Common;
using CommonSolution.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;

namespace ExternalWebhookReceiverAPI.Application.Services.Hotmart
{
    public class HotmartWebhookService : IHotmartWebhookService
    {
        private readonly IExternalAuthenticationService _externalAuthService;
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IExternalWebhookReceiverService _externalWebhookReceiverService;
        private readonly IValidator<HotmartWebhookDTO> _validator;
        private readonly IBusinessUnitService _externalBusinessUnitService;
        public HotmartWebhookService(IExternalAuthenticationService externalAuthService,
            IOptions<DefaultUserService> defaultUser,
            IExternalWebhookReceiverService externalWebhookReceiverService,
            IValidator<HotmartWebhookDTO> validator,
            IBusinessUnitService externalBusinessUnitService
            )
        {
            _externalAuthService = externalAuthService;
            _defaultUser = defaultUser;
            _externalWebhookReceiverService = externalWebhookReceiverService;
            _validator = validator;
            _externalBusinessUnitService = externalBusinessUnitService;
        }
        public async Task<HotmartWebhookDTO> HandleWebhookService(HotmartWebhookDTO payload, ExternalAuthenticationDTO externalAuth)
        {
            var validationResult = await _validator.ValidateAsync(payload);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            ExternalAuthentication? externalAuthentication = await _externalAuthService.GetExternalAuthenticationFromTokenAsync(externalAuth);
            BusinessUnit? businessUnit = await _externalBusinessUnitService.GetBusinessUnitById(externalAuthentication.BusinessUnitId);

            await _externalWebhookReceiverService.ValidationExternalWebhookReceiverIdentifier(payload.Id, businessUnit);

            DefaultUserService defaultUser = _defaultUser.Value;
            ExternalWebhookReceiver externalWebhookReceiver = HotmartWebhookMapper.ToExternalWebhookReceiver(
                dto: payload,
                businessUnit: businessUnit,
                sourceType: ExternalWebhookReceiverSourceType.Hotmart,
                defaultUser: defaultUser
            );

            await _externalWebhookReceiverService.InsertExternalWebhookReceiver(externalWebhookReceiver);

            return await Task.FromResult(payload);
        }
    }
}
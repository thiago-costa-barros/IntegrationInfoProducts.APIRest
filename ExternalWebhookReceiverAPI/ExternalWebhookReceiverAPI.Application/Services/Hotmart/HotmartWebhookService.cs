using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Mappings.Hotmart;
using FluentValidation;
using Microsoft.Extensions.Options;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;
using CommonSolution.Domain.Entities.Common;
using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;
using CommonSolution.Domain.Entities.Common.Enums;
using CommonSolution.Utils.Mappers;

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

            ExternalAuthentication? externalAuthentication = await _externalAuthService.GetExternalAuthenticationByToken(externalAuth);
            BusinessUnit? businessUnit = await _externalBusinessUnitService.GetBusinessUnitById(externalAuthentication.BusinessUnitId);

            await _externalWebhookReceiverService.ValidationExternalWebhookReceiverIdentifier(payload.Id, businessUnit);

            DefaultUserService defaultUser = _defaultUser.Value;
            ExternalWebhookReceiver externalWebhookReceiver = HotmartWebhookMapper.ToExternalWebhookReceiver(
                dto: payload,
                businessUnit: businessUnit,
                sourceType: ExternalWebhookReceiverSourceType.Hotmart,
                defaultUser: defaultUser
            );

            ExternalWebhookReceiver newExternalWebhookReceiver = await _externalWebhookReceiverService.InsertExternalWebhookReceiver(externalWebhookReceiver);

            ExternalWebhookReceiverStatusHistoric externalWebhookReceiverStatusHistoric = GenericStatusHistoricMapper.Map<ExternalWebhookReceiverStatusHistoric, ExternalWebhookReceiverStatus>(
                entityId: newExternalWebhookReceiver.ExternalWebhookReceiverId,
                status: newExternalWebhookReceiver.Status,
                userId: defaultUser.DefaultUserId,
                message: null
            );
            return await Task.FromResult(payload);
        }
    }
}
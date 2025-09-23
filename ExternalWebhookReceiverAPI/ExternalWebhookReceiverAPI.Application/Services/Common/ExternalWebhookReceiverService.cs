using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    public class ExternalWebhookReceiverService : IExternalWebhookReceiverService
    {
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        public ExternalWebhookReceiverService(IExternalWebhookReceiverRepository externalWebhookReceiverRepository)
        {
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
        }
        public async Task InsertExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver)
        {
            await _externalWebhookReceiverRepository.InsertExternalWebhookAsync(externalWebhookReceiver);
        }

        public async Task ValidationExternalWebhookReceiverIdentifier(string identifier, BusinessUnit businessUnit)
        {
            ExternalWebhookReceiver? existExternalWebhookReceiver = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(identifier, businessUnit);
            if (existExternalWebhookReceiver != null)
                throw new ArgumentException(string.Format(HotmartMessages.EXC0002, identifier));
        }
    }
}

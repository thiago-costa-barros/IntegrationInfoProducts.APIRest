using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;
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
        public async Task<ExternalWebhookReceiver> InsertExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver)
        {
            ExternalWebhookReceiver result = await _externalWebhookReceiverRepository.InsertExternalWebhookAsync(externalWebhookReceiver);
            return result;
        }

        public async Task InsertExternalWebhookReceiverStatusHistoric(ExternalWebhookReceiverStatusHistoric externalWebhookReceiverStatusHistoric)
        {
            await _externalWebhookReceiverRepository.InsertExternalWebhookReceiverStatusHistoric(externalWebhookReceiverStatusHistoric);
        }

        public async Task ValidationExternalWebhookReceiverIdentifier(string identifier, BusinessUnit businessUnit)
        {
            ExternalWebhookReceiver? existExternalWebhookReceiver = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(identifier, businessUnit);
            if (existExternalWebhookReceiver != null)
                throw new ArgumentException(string.Format(HotmartMessages.EXC0002, identifier, businessUnit.BusinessUnitId));
        }
    }
}

using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalWebhookReceiverRepository : IExternalWebhookReceiverRepository
    {
        private readonly IExternalWebhookReceiverDAO _externalWebhookReceiverDAO;
        public ExternalWebhookReceiverRepository(IExternalWebhookReceiverDAO externalWebhookReceiverDAO)
        {
            _externalWebhookReceiverDAO = externalWebhookReceiverDAO;
        }

        public async Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(string? identifier, BusinessUnit businessUnit)
        {
            ExternalWebhookReceiver? result = await _externalWebhookReceiverDAO.GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(identifier, businessUnit);

            return result;
        }

        public async Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver)
        {
            await _externalWebhookReceiverDAO.InsertExternalWebhookAsync(externalWebhookReceiver);
        }
    }
}

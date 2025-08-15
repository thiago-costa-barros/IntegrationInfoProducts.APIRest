using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
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

        public async Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdenitifierAndCompanyId(string? identifier, Company company)
        {
            ExternalWebhookReceiver? result = await _externalWebhookReceiverDAO.GetExternalWebhookReceiverByIdenitifierAndCompanyId(identifier, company);

            return result;
        }

        public async Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver)
        {
            await _externalWebhookReceiverDAO.InsertExternalWebhookAsync(externalWebhookReceiver);
        }
    }
}

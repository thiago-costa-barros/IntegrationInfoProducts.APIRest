using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class ExternalWebhookReceiverRepository : IExternalWebhookReceiverRepository
    {
        private readonly IExternalWebhookReceiverDAO _externalWebhookReceiverDAO;
        public ExternalWebhookReceiverRepository(IExternalWebhookReceiverDAO externalWebhookReceiverDAO)
        {
            _externalWebhookReceiverDAO = externalWebhookReceiverDAO;
        }

        public async Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdenitifierAndCompanyId(HotmartWebhookDTO payload, Company company)
        {
            ExternalWebhookReceiver? result = await _externalWebhookReceiverDAO.GetExternalWebhookReceiverByIdenitifierAndCompanyId(payload, company);

            return result;
        }

        public async Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver)
        {
            await _externalWebhookReceiverDAO.InsertExternalWebhookAsync(externalWebhookReceiver);
        }
    }
}

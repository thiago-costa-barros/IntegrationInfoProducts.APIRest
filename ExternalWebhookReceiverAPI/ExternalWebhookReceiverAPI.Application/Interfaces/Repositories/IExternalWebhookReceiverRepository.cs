using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for repository operations related to ExternalWebhookReceiver.
    /// Responsible for delegating data access to DAO and mapping results to domain models.
    /// </summary>
    public interface IExternalWebhookReceiverRepository
    {
        Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
        Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdenitifierAndCompanyId(HotmartWebhookDTO payload, Company company);
    }
}

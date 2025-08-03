using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    /// <summary>
    /// Defines the data access operations for the ExternalWebhookReceiver entity.
    /// Uses Entity Framework to execute queries directly against the database.
    /// </summary>
    public interface IExternalWebhookReceiverDAO
    {
        Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver);
        Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdenitifierAndCompanyId(HotmartWebhookDTO payload, Company company);
    }
}

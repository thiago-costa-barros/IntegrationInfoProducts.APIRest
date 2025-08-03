using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
using ExternalWebhookReceiverAPI.Domain.Entities;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    public class ExternalWebhookReceiverDAO : IExternalWebhookReceiverDAO
    {
        private readonly ApplicationDbContext _context;
        public ExternalWebhookReceiverDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver)
        {
            var dateNow = DateTime.UtcNow;

            externalWebhookReceiver.CreationDate = dateNow;
            externalWebhookReceiver.UpdateDate = dateNow;

            _context.ExternalWebhookReceiver.Add(externalWebhookReceiver);
            
            await _context.SaveChangesAsync();
        }
    }
}

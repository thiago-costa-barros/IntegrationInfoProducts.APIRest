using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Interfaces.DAOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    public class ExternalWebhookReceiverDAO : IExternalWebhookReceiverDAO
    {
        private readonly ApplicationDbContext _context;
        public ExternalWebhookReceiverDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdenitifierAndCompanyId(string identifier, Company company)
        {
            ExternalWebhookReceiver? result = await _context.ExternalWebhookReceiver
                .FirstOrDefaultAsync(x =>
                x.ExternalIdentifier == identifier &&
                x.CompanyId == company.CompanyId &&
                x.DeletionDate == null);

            return result;
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

using CommonSolution.CrossCutting;
using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;
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

        public async Task<ExternalWebhookReceiver?> GetExternalWebhookReceiverByIdentifierAndBusinessUnitId(string identifier, BusinessUnit businessUnit)
        {
            ExternalWebhookReceiver? result = await _context.Set<ExternalWebhookReceiver>()
                .FirstOrDefaultAsync(x =>
                x.ExternalIdentifier == identifier &&
                x.BusinessUnitId == businessUnit.BusinessUnitId &&
                x.DeletionDate == null);

            return result;
        }

        public async Task InsertExternalWebhookAsync(ExternalWebhookReceiver externalWebhookReceiver)
        {
            var dateNow = DateTime.UtcNow;

            externalWebhookReceiver.CreationDate = dateNow;
            externalWebhookReceiver.UpdateDate = dateNow;

            _context.Set<ExternalWebhookReceiver>().Add(externalWebhookReceiver);

            await _context.SaveChangesAsync();
        }
    }
}

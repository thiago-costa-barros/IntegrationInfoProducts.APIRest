using CommonSolution.Entities;
using CommonSolution.Interfaces;

namespace ExternalWebhookReceiverAPI.Domain.Entities
{
    public class ExternalWebhookReceiver : AuditableEntity
    {
        public int ExternalWebhookReceiverId { get; set; }

        public int SourceType { get; set; }
        public int Status { get; set; }
        public int CompanyId { get; set; }
        public string ExternalIdentifier { get; set; }
        public string Payload { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
    }
}

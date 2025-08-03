using CommonSolution.Entities;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExternalWebhookReceiverAPI.Domain.Entities
{
    [Table("ExternalWebhookReceiver", Schema = "IntegrationSchema")]
    public class ExternalWebhookReceiver : AuditableEntity
    {
        public int ExternalWebhookReceiverId { get; set; }
        public ExternalWebhookReceiverSourceType SourceType { get; set; }
        public ExternalWebhookReceiverStatus Status { get; set; }
        public int CompanyId { get; set; }
        public string? ExternalIdentifier { get; set; }
        public string? Payload { get; set; }
    }
}

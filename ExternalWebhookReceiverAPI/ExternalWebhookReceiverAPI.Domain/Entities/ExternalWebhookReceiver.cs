using CommonSolution.Entities;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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
        public JsonElement Payload { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public required Company Company { get; set; }
    }
}

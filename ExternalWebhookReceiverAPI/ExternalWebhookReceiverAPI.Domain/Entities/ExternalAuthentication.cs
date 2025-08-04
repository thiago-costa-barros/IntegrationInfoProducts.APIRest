using CommonSolution.Entities;
using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExternalWebhookReceiverAPI.Domain.Entities
{
    [Table("ExternalAuthentication", Schema = "IntegrationSchema")]
    public class ExternalAuthentication : AuditableEntity
    {
        public int ExternalAuthenticationId { get; set; }

        public ExternalAuthenticationType AuthType { get; set; }
        public string? AuthKey { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public required Company Company { get; set; }
    }
}

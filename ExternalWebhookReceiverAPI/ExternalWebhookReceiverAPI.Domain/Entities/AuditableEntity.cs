using ExternalWebhookReceiverAPI.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Domain.Entities
{
    public class AuditableEntity : IAuditableEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeletionDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? UpdateUserId { get; set; }
    }
}

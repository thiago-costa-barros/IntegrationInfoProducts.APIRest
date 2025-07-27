using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Domain.Entities
{
    public class UserToken : AuditableEntity
    {
        public int UserTokenId { get; set; }
        public int UserId { get; set; }
        public string JwtToken { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public TokenType Type { get; set; }
        public TokenStatus Status { get; set; }
        public Guid Identifier { get; set; }
        public User? User { get; set; } = null!;
    }
}

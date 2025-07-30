using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Application.DTOs
{
    public class TokenValidationResultDTO
    {
        public TokenStatus TokenStatus { get; set; }
        public int? Userid { get; set; }
        public string? Token { get; set; }
        public TokenType TokenType { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}

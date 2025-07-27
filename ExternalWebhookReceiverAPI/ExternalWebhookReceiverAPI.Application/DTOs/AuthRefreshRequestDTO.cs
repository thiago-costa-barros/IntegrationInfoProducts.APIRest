using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Application.DTOs
{
    public class AuthRefreshRequestDTO
    {
        public string? RefreshToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Application.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(128, MinimumLength = 8)]
        public string? Login { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 8)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256, MinimumLength = 10)]
        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}

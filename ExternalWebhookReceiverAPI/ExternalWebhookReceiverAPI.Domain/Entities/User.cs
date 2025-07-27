using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Login), IsUnique = true)]
public class User : AuditableEntity
{
    public int UserId { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsAdmin { get; set; } = false;
    public UserType Type { get; set; } = UserType.TeamUser;

}

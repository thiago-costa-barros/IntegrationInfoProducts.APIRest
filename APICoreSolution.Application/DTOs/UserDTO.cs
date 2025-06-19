using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Application.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

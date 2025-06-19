using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Application.DTOs
{
    public class AuthLoginRequestDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

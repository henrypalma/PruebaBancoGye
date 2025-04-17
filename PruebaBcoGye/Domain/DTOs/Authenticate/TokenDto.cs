using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Authenticate
{
    public class TokenDto
    {
        public int IdUsuario { get; set; }
        public string? Login { get; set; }
        public string? Token { get; set; }
    }
}

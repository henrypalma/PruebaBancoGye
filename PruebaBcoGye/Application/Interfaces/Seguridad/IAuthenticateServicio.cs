using Domain.DTOs.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Seguridad
{
    public interface IAuthenticateServicio
    {
        Task<TokenDto> AuthenticateLogin(LoginDto request);
    }
}

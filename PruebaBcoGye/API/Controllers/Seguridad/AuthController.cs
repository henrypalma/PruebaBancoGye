using Application.Interfaces.Seguridad;
using Domain.DTOs.Authenticate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.Seguridad
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IAuthenticateServicio authenticateService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto request)
        {
            var response = await authenticateService.AuthenticateLogin(request);
            return Ok(response);
        }
    }
}

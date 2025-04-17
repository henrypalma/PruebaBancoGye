using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController(IClienteServicio clienteServicio) : ControllerBase
    {
        [Authorize]
        [HttpGet("consultar")]
        public async Task<List<ClientesDto>> Consultar()
        {
            return await clienteServicio.ConsultarTodo();
        }

        [Authorize]
        [HttpGet]
        public async Task<ClientesDto> Consultar([FromQuery] int id)
        {
            return await clienteServicio.ConsultarPorId(id);
        }
    }
}

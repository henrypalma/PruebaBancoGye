using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController(IClienteServicio clienteServicio) : ControllerBase
    {
        [HttpGet("consultar")]
        public async Task<List<ClientesDto>> Consultar()
        {
            return await clienteServicio.ConsultarTodo();
        }

        [HttpGet]
        public async Task<ClientesDto> Consultar([FromQuery] int id)
        {
            return await clienteServicio.ConsultarPorId(id);
        }
    }
}

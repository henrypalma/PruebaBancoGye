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

        [Authorize]
        [HttpPost]
        public async Task Grabar([FromBody] ClientesDto clienteDto)
        {
            await clienteServicio.Grabar(clienteDto);
        }

        [Authorize]
        [HttpPost("actualizar")]
        public async Task Actualizar([FromBody] ClientesDto clienteDto)
        {
            await clienteServicio.Actualizar(clienteDto);
        }

        [Authorize]
        [HttpPost("eliminar")]
        public async Task Eliminar([FromQuery] int id)
        {
            await clienteServicio.Eliminar(id);
        }
    }
}

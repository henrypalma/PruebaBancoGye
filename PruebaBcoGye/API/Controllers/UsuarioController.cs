using Application.Interfaces;
using Application.Servicios;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController(IUsuarioVendedorServicio usuarioServicio) : ControllerBase
    {
        [HttpGet("consultar")]
        public async Task<List<UsuarioVendedorDto>> Consultar()
        {
            return await usuarioServicio.ConsultarTodo();
        }

        [HttpGet]
        public async Task<UsuarioVendedorDto> Consultar([FromQuery] int id)
        {
            return await usuarioServicio.ConsultarPorId(id);
        }

        [Authorize]
        [HttpPost]
        public async Task Grabar([FromBody] UsuarioVendedorDto usuariosDto)
        {
            await usuarioServicio.Grabar(usuariosDto);
        }

        [Authorize]
        [HttpPost("actualizar")]
        public async Task Actualizar([FromBody] UsuarioVendedorDto usuariosDto)
        {
            await usuarioServicio.Actualizar(usuariosDto);
        }

        [Authorize]
        [HttpPost("eliminar")]
        public async Task Eliminar([FromQuery] int id)
        {
            await usuarioServicio.Eliminar(id);
        }

    }
}

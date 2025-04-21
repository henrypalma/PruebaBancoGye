using Application.Interfaces;
using Application.Servicios;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("producto")]
    [ApiController]
    public class ProductoController(IProductoServicio productoServicio) : ControllerBase
    {
        [HttpGet("consultar")]
        public async Task<List<ProductosDto>> Consultar()
        {
            return await productoServicio.ConsultarTodo();
        }

        [HttpGet]
        public async Task<ProductosDto> Consultar([FromQuery] int id)
        {
            return await productoServicio.ConsultarPorId(id);
        }

        [Authorize]
        [HttpPost]
        public async Task Grabar([FromBody] ProductosDto productosDto)
        {
            await productoServicio.Grabar(productosDto);
        }

        [Authorize]
        [HttpPost("actualizar")]
        public async Task Actualizar([FromBody] ProductosDto productosDto)
        {
            await productoServicio.Actualizar(productosDto);
        }

        [Authorize]
        [HttpPost("eliminar")]
        public async Task Eliminar([FromQuery] int id)
        {
            await productoServicio.Eliminar(id);
        }
    }
}

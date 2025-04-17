using Application.Interfaces;
using Application.Servicios;
using Domain.DTOs;
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
    }
}

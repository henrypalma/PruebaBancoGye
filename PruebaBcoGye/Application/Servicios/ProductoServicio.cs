using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;
using Mapster;

namespace Application.Servicios
{
    public class ProductoServicio(IProductoRepositorio productoRepositorio) : IProductoServicio
    {
        public async Task<List<ProductosDto>> ConsultarTodo()
        {
            var productos = await productoRepositorio.ConsultarTodosAsync();
            var productosdto = productos.Adapt<IEnumerable<ProductosDto>>().ToList();
            return productosdto;
        }

        public async Task<ProductosDto> ConsultarPorId(int id)
        {
            var producto = await productoRepositorio.ConsultarPorIdAsync(id);
            var productodto = producto.Adapt<ProductosDto>();
            return productodto;
        }

    }
}

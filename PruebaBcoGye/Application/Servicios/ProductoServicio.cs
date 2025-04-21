using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;
using Mapster;
using Domain.Entidades;

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

        public async Task Grabar(ProductosDto dto)
        {
            var producto = dto.Adapt<Productos>();
            await productoRepositorio.GrabarAsync(producto);
        }

        public async Task Actualizar(ProductosDto dto)
        {
            var producto = dto.Adapt<Productos>();
            await productoRepositorio.ActualizarAsync(producto);
        }

        public async Task Eliminar(int id)
        {
            var producto = await productoRepositorio.ConsultarPorIdAsync(id);
            producto.Estado = (short)EstadoRegistro.Inactivo;
            producto.FechaModificacion = DateTime.Now;
            await productoRepositorio.ActualizarAsync(producto);
        }

    }
}

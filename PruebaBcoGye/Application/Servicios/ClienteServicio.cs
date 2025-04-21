using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;
using Mapster;
using Domain.Entidades;
using System.Runtime.InteropServices;

namespace Application.Servicios
{
    public class ClienteServicio(IClientesRepositorio clientesRepositorio) : IClienteServicio
    {
        public async Task<List<ClientesDto>> ConsultarTodo()
        {
            var clientes = await clientesRepositorio.ConsultarTodosAsync();
            var clientedto = clientes.Adapt<IEnumerable<ClientesDto>>().ToList();
            return clientedto;
        }

        public async Task<ClientesDto> ConsultarPorId(int id)
        {
            var clientes = await clientesRepositorio.ConsultarPorIdAsync(id);
            var clientedto = clientes.Adapt<ClientesDto>();
            return clientedto;
        }

        public async Task Grabar(ClientesDto dto)
        {
            var cliente = dto.Adapt<Clientes>();
            await clientesRepositorio.GrabarAsync(cliente);
        }

        public async Task Actualizar(ClientesDto dto)
        {
            var cliente = dto.Adapt<Clientes>();
            await clientesRepositorio.ActualizarAsync(cliente);
        }

        public async Task Eliminar(int id)
        {
            var cliente = await clientesRepositorio.ConsultarPorIdAsync(id);
            cliente.Estado = (short)EstadoRegistro.Inactivo;
            cliente.FechaModificacion = DateTime.Now;
            await clientesRepositorio.ActualizarAsync(cliente);
        }
    }
}

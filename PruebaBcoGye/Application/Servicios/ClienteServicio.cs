using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;
using Mapster;

namespace Application.Servicios
{
    public class ClienteServicio(IClientesRepositorio clientesRepositorio) : IClienteServicio
    {
        public async Task<List<ClientesDto>> Consultar()
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
    }
}

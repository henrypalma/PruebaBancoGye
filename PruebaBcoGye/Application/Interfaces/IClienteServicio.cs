using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteServicio
    {
        Task<List<ClientesDto>> ConsultarTodo();
        Task<ClientesDto> ConsultarPorId(int id);
        Task Grabar(ClientesDto dto);
        Task Actualizar(ClientesDto dto);
        Task Eliminar(int id);
    }
}

using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioVendedorServicio
    {

        Task<List<UsuarioVendedorDto>> ConsultarTodo();
        Task<UsuarioVendedorDto> ConsultarPorId(int id);

        Task Grabar(UsuarioVendedorDto dto);
        Task Actualizar(UsuarioVendedorDto dto);
        Task Eliminar(int id);
    }
}

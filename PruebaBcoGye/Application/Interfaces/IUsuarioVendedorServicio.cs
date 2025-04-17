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
        Task<UsuarioVendedorDto> ConsultarPorId(int id);
    }
}

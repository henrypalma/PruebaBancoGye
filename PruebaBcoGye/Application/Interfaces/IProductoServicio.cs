using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoServicio
    {
        Task<List<ProductosDto>> ConsultarTodo();
        Task<ProductosDto> ConsultarPorId(int id);
    }
}

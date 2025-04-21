using Domain.DTOs;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IUsuarioVendedorRepositorio : IRepositorioBase<UsuarioVendedor>
    {
        Task<UsuarioVendedor?> ConsultarPorLogin(string login);
    }
}

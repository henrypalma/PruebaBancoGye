using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;

namespace Application.Servicios
{
    public class UsuarioVendedorServicio(IUsuarioVendedorRepositorio usuarioVendedorRepositorio) : IUsuarioVendedorServicio
    {
        public async Task<UsuarioVendedorDto>ConsultarPorId(int id)
        {
            var usuarioDto = await usuarioVendedorRepositorio.ConsultarPorId(id);
            return usuarioDto switch
            {
                null => throw new ApplicationException("Usuario no existe"),
                { Estado: (short)EstadoRegistro.Inactivo } => throw new ApplicationException("Usuario se encuentra inactivo"),
                _=> usuarioDto
            };
        }
    }
}
 
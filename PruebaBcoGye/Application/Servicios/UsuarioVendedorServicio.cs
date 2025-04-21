using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Repositorios;
using Domain.General;
using Domain.Entidades;
using Mapster;

namespace Application.Servicios
{
    public class UsuarioVendedorServicio(IUsuarioVendedorRepositorio usuarioVendedorRepositorio) : IUsuarioVendedorServicio
    {
        public async Task<UsuarioVendedorDto>ConsultarPorId(int id)
        {
            var usuario = await usuarioVendedorRepositorio.ConsultarPorIdAsync(id);
            var usuarioDto = usuario.Adapt<UsuarioVendedorDto>();
            return usuarioDto switch
            {
                null => throw new ApplicationException("Usuario no existe"),
                { Estado: (short)EstadoRegistro.Inactivo } => throw new ApplicationException("Usuario se encuentra inactivo"),
                _=> usuarioDto
            };
        }

        public async Task<List<UsuarioVendedorDto>> ConsultarTodo()
        {
            var usuarios = await usuarioVendedorRepositorio.ConsultarTodosAsync();
            var usuariosdto = usuarios.Adapt<IEnumerable<UsuarioVendedorDto>>().ToList();
            return usuariosdto;
        }

        public async Task Grabar(UsuarioVendedorDto dto)
        {
            var usuario = dto.Adapt<UsuarioVendedor>();
            await usuarioVendedorRepositorio.GrabarAsync(usuario);
        }

        public async Task Actualizar(UsuarioVendedorDto dto)
        {
            var usuario = dto.Adapt<UsuarioVendedor>();
            await usuarioVendedorRepositorio.ActualizarAsync(usuario);
        }

        public async Task Eliminar(int id)
        {
            var usuario = await usuarioVendedorRepositorio.ConsultarPorIdAsync(id);
            usuario.Estado = (short)EstadoRegistro.Inactivo;
            usuario.FechaModificacion = DateTime.Now;
            await usuarioVendedorRepositorio.ActualizarAsync(usuario);
        }
    }
}
 
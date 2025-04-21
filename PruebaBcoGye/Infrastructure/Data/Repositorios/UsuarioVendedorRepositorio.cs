using Domain.DTOs;
using Domain.Entidades;
using Domain.Repositorios;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositorios
{
    public class UsuarioVendedorRepositorio(ApplicationDbContext context) : 
        RepositorioBase<UsuarioVendedor>(context),
        IUsuarioVendedorRepositorio
    {        

        public async Task<UsuarioVendedor?> ConsultarPorLogin(string login)
        => await Context.UsuarioVendedor
            .Select(i => new UsuarioVendedor
            {
                Id = i.Id,
                Nombre = i.Nombre,
                Apellidos = i.Apellidos,
                DocumentoIdentidad = i.DocumentoIdentidad,
                Correo = i.Correo,
                Telefono = i.Telefono,
                Usuario = i.Usuario,
                Contrasenia = i.Contrasenia,
                Estado = i.Estado,
                FechaModificacion = i.FechaModificacion
            }).FirstOrDefaultAsync(i => i.Usuario == login);
    }
}

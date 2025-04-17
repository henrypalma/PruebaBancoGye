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
    public class ClientesRepositorio(ApplicationDbContext context) : RepositorioBase<Clientes>(context), IClientesRepositorio
    {
        //public async Task<List<Clientes>?> Consultar()
        
        //    => await Context.Clientes.ToListAsync();

        //public async Task<Clientes?> ConsultarPorId(int id)
        //    => await Context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        //public async Task Insertar(Clientes cliente)
        //{

        //}

    }   
}

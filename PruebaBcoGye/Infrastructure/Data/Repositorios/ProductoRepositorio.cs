using Domain.Entidades;
using Domain.Repositorios;
using Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositorios
{
    public class ProductoRepositorio(ApplicationDbContext context) : RepositorioBase<Productos>(context), IProductoRepositorio
    {
    }
}

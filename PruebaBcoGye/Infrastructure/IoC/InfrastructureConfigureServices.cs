using Azure.Core;
using Domain.Repositorios;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public static class InfrastructureConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddTransient<IUsuarioVendedorRepositorio, UsuarioVendedorRepositorio>();
            services.AddTransient<IClientesRepositorio, ClientesRepositorio>();
            services.AddTransient<IProductoRepositorio, ProductoRepositorio>();

            return services;
        }
    }
}

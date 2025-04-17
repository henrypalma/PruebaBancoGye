using Domain.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Seguridad;
using Application.Servicios.Seguridad;

namespace Infrastructure.IoC
{
    public static class ApplicationConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioVendedorServicio, UsuarioVendedorServicio>();
            services.AddTransient<IAuthenticateServicio, AuthenticateServicio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();
            services.AddTransient<IProductoServicio, ProductoServicio>();

            return services;
        }
    }
}

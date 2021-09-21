using AutoMapper;
using CadastroTeste.Entities;
using CadastroTeste.EntityFramework;
using CadastroTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.Config
{
    public static class GeneralProjectConfigs
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection ConfigureEntityDbContext(this IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<UsuarioContext>(options =>
            {
                options.UseInMemoryDatabase("CadastroDB");
            });

            return services;
        }


    }
}

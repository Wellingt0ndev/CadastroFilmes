﻿using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Infrastructure.Repositories;
using CadastroFilmes.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CadastroFilmes.IoC
{
    public static class Startup
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            ConfigureRepository(services);
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFilmeService, FilmeService>();
        }

        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddSingleton<IFilmeRepository, FilmeRepository>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LoLChampionsAPI.Dominio.Interfaces;
using LoLChampionsAPI.Infra.Repositorio;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LoLChampionsAPI.Infra.Configurations
{
    public static class InfraConfig
    {

        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioDeCampeao, RepositorioDeCampeaoDapper>();
            services.AddScoped<IDbConnection>(s =>
          {
              var configuration = s.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
              return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
          });

            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClinicIA.Infra.Data.Context;
using ClinicIA.Infra.Data.Repositories;
using FluentValidation;
using ClinicIA.Domain.Repositories;
using ClinicIA.Infra.Data.Queries;
using ClinicIA.Dto.Queries.Clinica;
using ClinicIA.Dto.Queries.Prontuario;

namespace ClinicIA.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Data Layer - Configuração para Supabase Transaction Pooler
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ClinicIAContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                    npgsqlOptions.CommandTimeout(60);
                });
            });

            services.AddScoped<IClinicaRepository, ClinicaRepository>();
            services.AddScoped<IProntuarioRepository, ProntuarioRepository>();

            services.AddScoped<IClinicaQuery, ClinicaQuery>();
            services.AddScoped<IProntuarioQuery, ProntuarioQuery>();

            // Application Layer (MediatR)
            var appAssembly = AppDomain.CurrentDomain.Load("ClinicIA.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));
            services.AddValidatorsFromAssembly(appAssembly);
        }
    }
}

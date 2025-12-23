using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CA.ClinicaIA.Infra.Data.Context;
using CA.ClinicaIA.Infra.Data.Repositories;
using FluentValidation;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Infra.Data.Queries;
using CA.ClinicaIA.Dto.Queries.Clinica;
using CA.ClinicaIA.Dto.Queries.Prontuario;

namespace CA.ClinicaIA.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Data Layer - Configuração para Supabase Transaction Pooler
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ClinicaIAContext>(options =>
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
            var appAssembly = AppDomain.CurrentDomain.Load("CA.ClinicaIA.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));
            services.AddValidatorsFromAssembly(appAssembly);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ClinicIA.Infra.Data.Tables;
using System.Reflection;

namespace ClinicIA.Infra.Data.Context
{
    public class ClinicIAContext : DbContext
    {
        public ClinicIAContext(DbContextOptions<ClinicIAContext> options) : base(options)
        {
        }

        public DbSet<ClinicaTable> Clinicas { get; set; }
        public DbSet<ProfissionalTable> Profissionais { get; set; }
        public DbSet<PacienteTable> Pacientes { get; set; }
        public DbSet<ProcedimentoTable> Procedimentos { get; set; }
        public DbSet<PlanoTable> Planos { get; set; }
        public DbSet<ProcedimentoPlanoTable> ProcedimentoPlanos { get; set; }
        public DbSet<AgendamentoTable> Agendamentos { get; set; }
        public DbSet<ProntuarioTable> Prontuarios { get; set; }
        public DbSet<GuiaTable> Guias { get; set; }
        public DbSet<GuiaProcedimentoTable> GuiaProcedimentos { get; set; }
        public DbSet<LancamentoFinanceiroTable> LancamentosFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Remove cascading delete by default
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

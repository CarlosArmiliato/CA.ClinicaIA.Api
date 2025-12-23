using CA.ClinicaIA.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class LancamentoFinanceiroTable : BaseTable
    {
        public TipoLancamento Tipo { get; set; }
        public decimal Valor { get; set; }
        public StatusLancamento Status { get; set; }
        public int AgendamentoId { get; set; }
        public int PacienteId { get; set; }

        public AgendamentoTable Agendamento { get; set; } = null!;
        public PacienteTable Paciente { get; set; } = null!;
    }

    public class LancamentoFinanceiroMap : IEntityTypeConfiguration<LancamentoFinanceiroTable>
    {
        public void Configure(EntityTypeBuilder<LancamentoFinanceiroTable> builder)
        {
            builder.ToTable("LancamentosFinanceiros");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Agendamento).WithMany(x => x.LancamentosFinanceiros).HasForeignKey(x => x.AgendamentoId);
            builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.PacienteId);
        }
    }

}

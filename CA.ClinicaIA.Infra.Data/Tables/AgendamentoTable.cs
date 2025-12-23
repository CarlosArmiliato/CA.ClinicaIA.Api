using System;
using CA.ClinicaIA.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class AgendamentoTable : BaseTable
    {
        public required int ClinicaId { get; set; }
        public required DateTimeOffset DataHora { get; set; }
        public required StatusAgendamento Status { get; set; }
        public required TipoAgendamento Tipo { get; set; }
        public required int ProfissionalId { get; set; }
        public required int PacienteId { get; set; }
        public required int ProcedimentoId { get; set; }
        public int? GuiaId { get; set; }
        public string? GoogleEventId { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
        public ProfissionalTable Profissional { get; set; } = null!;
        public PacienteTable Paciente { get; set; } = null!;
        public ProcedimentoTable Procedimento { get; set; } = null!;
        public ProntuarioTable Prontuario { get; set; } = null!;
        public GuiaTable? Guia { get; set; }
        public required ICollection<LancamentoFinanceiroTable> LancamentosFinanceiros { get; set; }
    }

    public class AgendamentoMap : IEntityTypeConfiguration<AgendamentoTable>
    {
        public void Configure(EntityTypeBuilder<AgendamentoTable> builder)
        {
            builder.ToTable("Agendamentos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Profissional)
                .WithMany()
                .HasForeignKey(x => x.ProfissionalId);

            builder.HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.PacienteId);

            builder.HasOne(x => x.Procedimento)
                .WithMany()
                .HasForeignKey(x => x.ProcedimentoId);

            builder.HasOne(x => x.Clinica)
                .WithMany()
                .HasForeignKey(x => x.ClinicaId);

            builder
                .HasOne(x => x.Prontuario)
                .WithOne(x => x.Agendamento)
                .HasForeignKey<ProntuarioTable>(x => x.AgendamentoId);

            builder.HasMany(x => x.LancamentosFinanceiros)
                .WithOne(x => x.Agendamento)
                .HasForeignKey(x => x.AgendamentoId);
        }
    }
}

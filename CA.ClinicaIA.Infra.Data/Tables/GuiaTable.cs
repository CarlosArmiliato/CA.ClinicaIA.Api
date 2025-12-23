using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class GuiaTable : BaseTable
    {
        public required int ClinicaId { get; set; }
        public required string Numero { get; set; }
        public required int PacienteId { get; set; }
        public required int PlanoId { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
        public PacienteTable Paciente { get; set; } = null!;
        public PlanoTable Plano { get; set; } = null!;
        public required ICollection<GuiaProcedimentoTable> Procedimentos { get; set; }
        public GuiaTable()
        {
            Procedimentos = [];
        }
    }

    public class GuiaMap : IEntityTypeConfiguration<GuiaTable>
    {
        public void Configure(EntityTypeBuilder<GuiaTable> builder)
        {
            builder.ToTable("Guias");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.PacienteId);

            builder.HasOne(x => x.Plano)
                .WithMany()
                .HasForeignKey(x => x.PlanoId);

            builder.HasOne(x => x.Clinica)
                .WithMany()
                .HasForeignKey(x => x.ClinicaId);
        }
    }
}

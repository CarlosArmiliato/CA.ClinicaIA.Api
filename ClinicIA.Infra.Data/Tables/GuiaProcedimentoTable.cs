using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicIA.Infra.Data.Tables
{
    public class GuiaProcedimentoTable : BaseTable
    {
        public required int GuiaId { get; set; }
        public required int ProcedimentoId { get; set; }
        public required int QuantidadeAutorizada { get; set; }
        public required int QuantidadeRealizada { get; set; }

        public GuiaTable Guia { get; set; } = null!;
        public ProcedimentoTable Procedimento { get; set; } = null!;
    }

    public class AtendimentoMap : IEntityTypeConfiguration<GuiaProcedimentoTable>
    {
        public void Configure(EntityTypeBuilder<GuiaProcedimentoTable> builder)
        {
            builder.ToTable("GuiasProcedimentos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Guia)
                .WithMany()
                .HasForeignKey(x => x.GuiaId);

            builder.HasOne(x => x.Procedimento)
                .WithMany()
                .HasForeignKey(x => x.ProcedimentoId);
        }
    }
}

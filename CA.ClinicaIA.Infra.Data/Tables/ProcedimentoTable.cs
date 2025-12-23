using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class ProcedimentoTable : BaseTable
    {
        public required int ClinicaId { get; set; }
        public required string Nome { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
        public ICollection<ProcedimentoPlanoTable> ProcedimentoPlanos { get; set; }

        public ProcedimentoTable()
        {
            ProcedimentoPlanos = [];
        }
    }

    public class ProcedimentoMap : IEntityTypeConfiguration<ProcedimentoTable>
    {
        public void Configure(EntityTypeBuilder<ProcedimentoTable> builder)
        {
            builder.ToTable("Procedimentos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Clinica)
                .WithMany()
                .HasForeignKey(x => x.ClinicaId);

            builder.HasMany(x => x.ProcedimentoPlanos)
                .WithOne(x => x.Procedimento)
                .HasForeignKey(x => x.ProcedimentoId);
        }
    }
}

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicIA.Infra.Data.Tables
{
    public class PlanoTable : BaseTable
    {
        public required int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required bool Intercambio { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
    }

    public class PlanoMap : IEntityTypeConfiguration<PlanoTable>
    {
        public void Configure(EntityTypeBuilder<PlanoTable> builder)
        {
            builder.ToTable("Planos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Clinica)
                .WithMany()
                .HasForeignKey(x => x.ClinicaId);
        }
    }
}

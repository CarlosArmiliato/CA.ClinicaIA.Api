using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicIA.Infra.Data.Tables
{
    public class ClinicaTable : BaseTable
    {
        public required string Nome { get; set; }
        public required string Configuracoes { get; set; }
    }

    public class ClinicaMap : IEntityTypeConfiguration<ClinicaTable>
    {
        public void Configure(EntityTypeBuilder<ClinicaTable> builder)
        {
            builder.ToTable("Clinicas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Configuracoes);
        }
    }
}

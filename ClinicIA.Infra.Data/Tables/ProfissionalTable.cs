using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicIA.Infra.Data.Tables
{
    public class ProfissionalTable : BaseTable
    {
        public required int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string? GoogleAccountId { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
    }

    public class ProfissionalMap : IEntityTypeConfiguration<ProfissionalTable>
    {
        public void Configure(EntityTypeBuilder<ProfissionalTable> builder)
        {
            builder.ToTable("Profissionais");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Clinica).WithMany().HasForeignKey(x => x.ClinicaId);
        }
    }
}

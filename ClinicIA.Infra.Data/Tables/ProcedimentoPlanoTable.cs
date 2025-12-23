using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicIA.Infra.Data.Tables
{
    public class ProcedimentoPlanoTable : BaseTable
    {
        public required int ProcedimentoId { get; set; }
        public required int PlanoId { get; set; }
        public decimal ValorCoparticipacao { get; set; }
        public decimal ValorProcedimento { get; set; }

        public ProcedimentoTable Procedimento { get; set; } = null!;
        public PlanoTable Plano { get; set; } = null!;
    }

    public class ProcedimentoPlanoMap : IEntityTypeConfiguration<ProcedimentoPlanoTable>
    {
        public void Configure(EntityTypeBuilder<ProcedimentoPlanoTable> builder)
        {
            builder.ToTable("ProcedimentoPlanos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Procedimento)
                .WithMany(x => x.ProcedimentoPlanos)
                .HasForeignKey(x => x.ProcedimentoId);

            builder.HasOne(x => x.Plano)
                .WithMany()
                .HasForeignKey(x => x.PlanoId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class ProntuarioTable : BaseTable
    {
        public required int AgendamentoId { get; set; }
        public required string TextoAudioOriginal { get; set; }
        public required string TextoProcessado { get; set; }

        public AgendamentoTable Agendamento { get; set; } = null!;
    }

    public class ProntuarioMap : IEntityTypeConfiguration<ProntuarioTable>
    {
        public void Configure(EntityTypeBuilder<ProntuarioTable> builder)
        {
            builder.ToTable("Prontuarios");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Agendamento).WithOne(x => x.Prontuario).HasForeignKey<ProntuarioTable>(x => x.AgendamentoId);
        }
    }
}

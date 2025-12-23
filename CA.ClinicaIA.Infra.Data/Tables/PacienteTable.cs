using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.ClinicaIA.Infra.Data.Tables
{
    public class PacienteTable : BaseTable
    {
        public int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required DateTime? DataNascimento { get; set; }
        public required string? Cpf { get; set; }
        public required string? CarteirinhaConvenio { get; set; }
        public required string? NomeResponsavel { get; set; }
        public required string? DocumentoResponsavel { get; set; }
        public required string? TelefoneResponsavel { get; set; }
        public required string? EmailResponsavel { get; set; }
        public required string? GoogleContactId { get; set; }

        public ClinicaTable Clinica { get; set; } = null!;
    }

    public class PacienteMap : IEntityTypeConfiguration<PacienteTable>
    {
        public void Configure(EntityTypeBuilder<PacienteTable> builder)
        {
            builder.ToTable("Pacientes");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Clinica).WithMany().HasForeignKey(x => x.ClinicaId);
        }
    }
}

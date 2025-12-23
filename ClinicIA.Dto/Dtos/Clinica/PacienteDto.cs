using System;

namespace ClinicIA.Dto.Dtos.Clinica
{
    public class PacienteDto
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required DateTime? DataNascimento { get; set; }
        public required string? Cpf { get; set; }
        public required string? CarteirinhaConvenio { get; set; }
        public required string? NomeResponsavel { get; set; }
        public required string? DocumentoResponsavel { get; set; }
        public required string? TelefoneResponsavel { get; set; }
        public required string? EmailResponsavel { get; set; }
        public required string? GoogleContactId { get; set; }
    }
}

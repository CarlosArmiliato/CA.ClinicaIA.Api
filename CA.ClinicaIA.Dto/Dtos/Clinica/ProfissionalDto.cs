using System;

namespace CA.ClinicaIA.Dto.Dtos.Clinica
{
    public class ProfissionalDto
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string? GoogleAccountId { get; set; }

    }
}

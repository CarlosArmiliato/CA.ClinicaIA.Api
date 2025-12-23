using System;

namespace ClinicIA.Dto.Dtos.Clinica
{
    public class ClinicaDto
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string Configuracoes { get; set; }
    }
}

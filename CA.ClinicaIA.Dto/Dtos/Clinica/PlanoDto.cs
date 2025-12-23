using System;
using System.Collections.Generic;

namespace CA.ClinicaIA.Dto.Dtos.Clinica
{
    public class PlanoDto
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required bool Intercambio { get; set; }
    }
}

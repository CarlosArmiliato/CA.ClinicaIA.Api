using System;
using System.Collections.Generic;

namespace ClinicIA.Dto.Dtos.Clinica
{
    public class ProcedimentoDto
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required ICollection<ProcedimentoPlanoDto> ProcedimentoPlanos { get; set; }
    }
}

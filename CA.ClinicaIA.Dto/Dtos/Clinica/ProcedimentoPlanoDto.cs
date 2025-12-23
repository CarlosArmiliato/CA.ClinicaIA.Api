using System;

namespace CA.ClinicaIA.Dto.Dtos.Clinica
{
    public class ProcedimentoPlanoDto
    {
        public required int Id { get; set; }
        public required PlanoDto Plano { get; set; }
        public required decimal ValorCoparticipacao { get; set; }
        public required decimal ValorProcedimento { get; set; }

    }
}

using ClinicIA.Domain.Enums;

namespace ClinicIA.Dto.Dtos.Prontuario
{
    public class AgendamentoDto
    {
        public required int Id { get; set; }
        public required DateTime Data { get; set; }
        public required StatusAgendamento Status { get; set; }
        public required TipoAgendamento Tipo { get; set; }
        public required ProfissionalDto Profissional { get; set; }
        public required PacienteDto Paciente { get; set; }
        public required ProcedimentoDto Procedimento { get; set; }
    }
}

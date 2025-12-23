using System;
using ClinicIA.Domain.Clinicas;
using ClinicIA.Domain.Enums;

namespace ClinicIA.Domain.Prontuario
{
    public class Agendamento
    {
        public int Id { get; }
        public DateTimeOffset DataHora { get; private set; }
        public StatusAgendamento Status { get; private set; }
        public TipoAgendamento Tipo { get; private set; }
        public string? GoogleEventId { get; private set; }

        public virtual ProfissionalResumo Profissional { get; private set; }
        public virtual PacienteResumo Paciente { get; private set; }
        public virtual ProcedimentoResumo Procedimento { get; private set; }

        public Agendamento(DateTimeOffset dataHora, StatusAgendamento status, TipoAgendamento tipo, string? googleEventId, ProfissionalResumo profissional, PacienteResumo paciente, ProcedimentoResumo procedimento)
        {
            DataHora = dataHora;
            Status = status;
            Tipo = tipo;
            GoogleEventId = googleEventId;
            Profissional = profissional;
            Paciente = paciente;
            Procedimento = procedimento;
        }

        public Agendamento(int id, DateTimeOffset dataHora, StatusAgendamento status, TipoAgendamento tipo, string? googleEventId, ProfissionalResumo profissional, PacienteResumo paciente, ProcedimentoResumo procedimento)
            : this(dataHora, status, tipo, googleEventId, profissional, paciente, procedimento)
        {
            Id = id;
        }
    }
}

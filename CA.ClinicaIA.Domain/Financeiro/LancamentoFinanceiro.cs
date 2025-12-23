using System;
using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Domain.Enums;
using CA.ClinicaIA.Domain.Prontuario;

namespace CA.ClinicaIA.Domain.Financeiro
{
    public class LancamentoFinanceiro
    {
        public int Id { get; }
        public TipoLancamento Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public StatusLancamento Status { get; private set; }

        public virtual Agendamento Agendamento { get; private set; }
        public virtual Paciente Paciente { get; private set; }

        public LancamentoFinanceiro(TipoLancamento tipo, decimal valor, Agendamento agendamento, Paciente paciente)
        {
            Tipo = tipo;
            Valor = valor;
            Status = StatusLancamento.Aberto;
            Agendamento = agendamento;
            Paciente = paciente;
        }

        public LancamentoFinanceiro(int id, TipoLancamento tipo, decimal valor, StatusLancamento status, Agendamento agendamento, Paciente paciente)
            : this(tipo, valor, agendamento, paciente)
        {
            Id = id;
            Status = status;
        }

        public void MarcarComoPago()
        {
            Status = StatusLancamento.Pago;
        }
    }
}

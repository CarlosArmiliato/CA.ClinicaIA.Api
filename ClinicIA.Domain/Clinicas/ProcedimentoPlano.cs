using System;

namespace ClinicIA.Domain.Clinicas
{
    public class ProcedimentoPlano
    {
        public int Id { get; }
        public decimal ValorCoparticipacao { get; private set; }
        public decimal ValorProcedimento { get; private set; }

        public virtual Plano Plano { get; private set; }

        public ProcedimentoPlano(Plano plano, decimal valorCoparticipacao, decimal valorProcedimento)
        {
            Plano = plano;
            ValorCoparticipacao = valorCoparticipacao;
            ValorProcedimento = valorProcedimento;
        }

        public ProcedimentoPlano(int id, Plano plano, decimal valorCoparticipacao, decimal valorProcedimento)
            : this(plano, valorCoparticipacao, valorProcedimento)
        {
            Id = id;
        }
    }
}

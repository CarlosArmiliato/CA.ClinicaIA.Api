using System;
using System.Collections.Generic;

namespace CA.ClinicaIA.Domain.Clinicas
{
    public class Procedimento
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public ICollection<ProcedimentoPlano> ProcedimentoPlanos { get; private set; }

        public Procedimento(string nome)
        {
            Nome = nome;
            ProcedimentoPlanos = [];
        }

        public Procedimento(int id, string nome, ICollection<ProcedimentoPlano> procedimentoPlanos)
            : this(nome)
        {
            Id = id;
            ProcedimentoPlanos = procedimentoPlanos;
        }
    }
}

using System;
using System.Collections.Generic;

namespace CA.ClinicaIA.Domain.Clinicas
{
    public class ProcedimentoResumo(int id, string nome)
    {
        public int Id { get; } = id;
        public string Nome { get; } = nome;
    }
}

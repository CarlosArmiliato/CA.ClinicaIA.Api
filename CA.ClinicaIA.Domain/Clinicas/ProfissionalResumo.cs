using System;

namespace CA.ClinicaIA.Domain.Clinicas
{
    public class ProfissionalResumo(int id, string nome)
    {
        public int Id { get; } = id;
        public string Nome { get; } = nome;
    }
}

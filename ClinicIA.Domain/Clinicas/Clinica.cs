using System;

namespace ClinicIA.Domain.Clinicas
{
    public class Clinica
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Configuracoes { get; private set; }

        public Clinica(string nome, string configuracoes)
        {
            Nome = nome;
            Configuracoes = configuracoes;
        }

        public Clinica(int id, string nome, string configuracoes)
            : this(nome, configuracoes)
        {
            Id = id;
        }

        public void Alterar(string nome, string configuracoes)
        {
            Nome = nome;
            Configuracoes = configuracoes;
        }
    }
}

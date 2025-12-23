using System;

namespace ClinicIA.Domain.Clinicas
{
    public class Profissional
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? GoogleAccountId { get; private set; }


        public Profissional(string nome, string email, string? googleAccountId)
        {
            Nome = nome;
            Email = email;
            GoogleAccountId = googleAccountId;
        }

        // Constructor for existing entities (retrieved from DB)
        public Profissional(int id, string nome, string email, string? googleAccountId)
            : this(nome, email, googleAccountId)
        {
            Id = id;
        }
    }
}

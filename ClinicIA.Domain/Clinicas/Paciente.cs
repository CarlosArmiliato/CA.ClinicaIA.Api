using System;

namespace ClinicIA.Domain.Clinicas
{
    public class Paciente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string? Cpf { get; private set; }
        public string? CarteirinhaConvenio { get; private set; }
        public string? NomeResponsavel { get; private set; }
        public string? DocumentoResponsavel { get; private set; }
        public string? TelefoneResponsavel { get; private set; }
        public string? EmailResponsavel { get; private set; }
        public string? GoogleContactId { get; private set; }

        public Paciente(string nome, DateTime? dataNascimento, string? cpf, string? carteirinhaConvenio, string? nomeResponsavel, string? documentoResponsavel, string? telefoneResponsavel, string? emailResponsavel)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            CarteirinhaConvenio = carteirinhaConvenio;
            NomeResponsavel = nomeResponsavel;
            DocumentoResponsavel = documentoResponsavel;
            TelefoneResponsavel = telefoneResponsavel;
            EmailResponsavel = emailResponsavel;
        }

        public Paciente(int id, string nome, DateTime? dataNascimento, string? cpf, string? carteirinhaConvenio, string? nomeResponsavel, string? documentoResponsavel, string? telefoneResponsavel, string? emailResponsavel, string? googleContactId)
        : this(nome, dataNascimento, cpf, carteirinhaConvenio, nomeResponsavel, documentoResponsavel, telefoneResponsavel, emailResponsavel)
        {
            Id = id;
            GoogleContactId = googleContactId;
        }

        public void Alterar(string nome, DateTime? dataNascimento, string? cpf, string? carteirinhaConvenio, string? nomeResponsavel, string? documentoResponsavel, string? telefoneResponsavel, string? emailResponsavel)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            CarteirinhaConvenio = carteirinhaConvenio;
            NomeResponsavel = nomeResponsavel;
            DocumentoResponsavel = documentoResponsavel;
            TelefoneResponsavel = telefoneResponsavel;
            EmailResponsavel = emailResponsavel;
        }
    }
}

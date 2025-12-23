namespace ClinicIA.Domain.Clinicas
{
    public class Plano
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public bool Intercambio { get; private set; }

        public Plano(string nome, bool intercambio)
        {
            Nome = nome;
            Intercambio = intercambio;
        }

        public Plano(int id, string nome, bool intercambio)
            : this(nome, intercambio)
        {
            Id = id;
        }
    }
}

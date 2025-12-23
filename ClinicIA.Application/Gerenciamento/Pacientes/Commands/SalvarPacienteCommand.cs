using System.Text.Json.Serialization;
using MediatR;

namespace ClinicIA.Application.Gerenciamento.Pacientes.Commands
{
    public class SalvarPacienteCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required DateTime? DataNascimento { get; set; }
        public required string? Cpf { get; set; }
        public required string? CarteirinhaConvenio { get; set; }
        public required string? NomeResponsavel { get; set; }
        public required string? DocumentoResponsavel { get; set; }
        public required string? TelefoneResponsavel { get; set; }
        public required string? EmailResponsavel { get; set; }
    }
}

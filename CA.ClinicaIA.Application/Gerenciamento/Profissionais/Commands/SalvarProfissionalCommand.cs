using System.Text.Json.Serialization;
using MediatR;

namespace CA.ClinicaIA.Application.Gerenciamento.Profissionais.Commands
{
    public class SalvarProfissionalCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? GoogleAccountId { get; set; }
    }
}

using System.Text.Json.Serialization;
using MediatR;

namespace CA.ClinicaIA.Application.Gerenciamento.Planos.Commands
{
    public class SalvarPlanoCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int ClinicaId { get; set; }
        public required string Nome { get; set; }
        public required bool Intercambio { get; set; }
    }
}

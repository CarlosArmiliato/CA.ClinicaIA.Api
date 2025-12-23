using System.Text.Json.Serialization;
using MediatR;

namespace CA.ClinicaIA.Application.Gerenciamento.Clinicas.Commands
{
    public class SalvarClinicaCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Configuracoes { get; set; }
    }
}

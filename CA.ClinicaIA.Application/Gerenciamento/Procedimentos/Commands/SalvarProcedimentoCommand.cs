using System.Text.Json.Serialization;
using MediatR;

namespace CA.ClinicaIA.Application.Gerenciamento.Procedimentos.Commands
{
    public class SalvarProcedimentoCommand : IRequest<int>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int ClinicaId { get; set; }
        public required string Nome { get; set; }
    }
}

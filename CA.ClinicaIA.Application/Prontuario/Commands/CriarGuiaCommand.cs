using MediatR;

namespace CA.ClinicaIA.Application.UseCases.Guias.Commands
{
    public class CriarGuiaCommand : IRequest<int>
    {
        public required string Numero { get; set; }
        public required int PacienteId { get; set; }
        public required int PlanoId { get; set; }
    }
}

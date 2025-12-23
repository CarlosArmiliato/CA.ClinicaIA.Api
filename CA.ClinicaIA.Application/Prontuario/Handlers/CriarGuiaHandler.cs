using MediatR;
using CA.ClinicaIA.Application.UseCases.Guias.Commands;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Prontuario;

namespace CA.ClinicaIA.Application.UseCases.Guias.Handlers
{
    public class CriarGuiaHandler : IRequestHandler<CriarGuiaCommand, int>
    {
        private readonly IProntuarioRepository _repository;

        public CriarGuiaHandler(IProntuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CriarGuiaCommand request, CancellationToken cancellationToken)
        {
            return 0;
            // var guia = new Guia(request.Numero, request.PacienteId, request.PlanoId);
            // await _repository.SalvarGuiaAsync(guia);

            // return new GuiaDto
            // {
            //     Id = guia.Id,
            //     Numero = guia.Numero,
            //     PacienteId = guia.PacienteId,
            //     PlanoId = guia.PlanoId
            // };
        }
    }
}

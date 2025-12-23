using MediatR;
using ClinicIA.Application.UseCases.Guias.Commands;
using ClinicIA.Domain.Repositories;
using ClinicIA.Domain.Prontuario;

namespace ClinicIA.Application.UseCases.Guias.Handlers
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

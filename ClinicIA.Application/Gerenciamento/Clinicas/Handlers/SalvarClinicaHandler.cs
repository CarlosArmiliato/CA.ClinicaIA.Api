using MediatR;
using ClinicIA.Application.Gerenciamento.Clinicas.Commands;
using ClinicIA.Domain.Repositories;
using ClinicIA.Domain.Clinicas;

namespace ClinicIA.Application.UseCases.Clinicas.Handlers
{
    public class SalvarClinicaHandler : IRequestHandler<SalvarClinicaCommand, int>
    {
        private readonly IClinicaRepository _repository;

        public SalvarClinicaHandler(IClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SalvarClinicaCommand request, CancellationToken cancellationToken)
        {
            Clinica? clinica;

            if (request.Id == 0)
            {
                clinica = new Clinica(request.Nome, request.Configuracoes);
            }
            else
            {
                clinica = await _repository.GetClinicaByIdAsync(request.Id);

                if (clinica == null)
                    throw new Exception("Clinica não encontrada");

                clinica.Alterar(request.Nome, request.Configuracoes);
            }

            var id = await _repository.SalvarClinicaAsync(clinica);

            return id;
        }
    }
}

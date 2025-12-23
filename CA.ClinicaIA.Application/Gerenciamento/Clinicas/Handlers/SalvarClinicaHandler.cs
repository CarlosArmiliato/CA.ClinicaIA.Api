using MediatR;
using CA.ClinicaIA.Application.Gerenciamento.Clinicas.Commands;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;

namespace CA.ClinicaIA.Application.UseCases.Clinicas.Handlers
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

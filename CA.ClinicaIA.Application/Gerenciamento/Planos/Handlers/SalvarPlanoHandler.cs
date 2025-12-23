using MediatR;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Application.Gerenciamento.Planos.Commands;

namespace CA.ClinicaIA.Application.Gerenciamento.Planos.Handlers
{
    public class SalvarPlanoHandler : IRequestHandler<SalvarPlanoCommand, int>
    {
        private readonly IClinicaRepository _repository;

        public SalvarPlanoHandler(IClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SalvarPlanoCommand request, CancellationToken cancellationToken)
        {
            var clinica = await _repository.GetClinicaByIdAsync(request.ClinicaId);

            if (clinica == null)
                throw new Exception("Clinica não encontrada");

            Plano? plano;

            if (request.Id == 0)
            {
                plano = new Plano(
                    request.Nome,
                    request.Intercambio);
            }
            else
            {
                plano = await _repository.GetPlanoByIdAsync(clinica, request.Id);

                if (plano == null)
                    throw new Exception("Plano não encontrado");

                plano = new Plano(
                    request.Id,
                    request.Nome,
                    request.Intercambio);
            }

            var id = await _repository.SalvarPlanoAsync(clinica, plano);

            return id;
        }
    }
}

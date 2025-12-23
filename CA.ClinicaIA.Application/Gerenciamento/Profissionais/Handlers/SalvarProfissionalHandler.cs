using MediatR;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Application.Gerenciamento.Profissionais.Commands;

namespace CA.ClinicaIA.Application.Gerenciamento.Profissionais.Handlers
{
    public class SalvarProfissionalHandler : IRequestHandler<SalvarProfissionalCommand, int>
    {
        private readonly IClinicaRepository _repository;

        public SalvarProfissionalHandler(IClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SalvarProfissionalCommand request, CancellationToken cancellationToken)
        {
            var clinica = await _repository.GetClinicaByIdAsync(request.ClinicaId);

            if (clinica == null)
                throw new Exception("Clinica não encontrada");

            Profissional? profissional;

            if (request.Id == 0)
            {
                profissional = new Profissional(
                    request.Nome,
                    request.Email,
                    request.GoogleAccountId);
            }
            else
            {
                profissional = await _repository.GetProfissionalByIdAsync(clinica, request.Id);

                if (profissional == null)
                    throw new Exception("Profissional não encontrado");

                profissional.Alterar(
                    request.Nome,
                    request.Email,
                    request.GoogleAccountId);
            }

            var id = await _repository.SalvarProfissionalAsync(clinica, profissional);

            return id;
        }
    }
}

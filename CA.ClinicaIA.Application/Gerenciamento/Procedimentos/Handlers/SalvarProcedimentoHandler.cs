using MediatR;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Application.Gerenciamento.Procedimentos.Commands;

namespace CA.ClinicaIA.Application.Gerenciamento.Procedimentos.Handlers
{
    public class SalvarProcedimentoHandler : IRequestHandler<SalvarProcedimentoCommand, int>
    {
        private readonly IClinicaRepository _repository;

        public SalvarProcedimentoHandler(IClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SalvarProcedimentoCommand request, CancellationToken cancellationToken)
        {
            var clinica = await _repository.GetClinicaByIdAsync(request.ClinicaId);

            if (clinica == null)
                throw new Exception("Clinica não encontrada");

            Procedimento? procedimento;

            if (request.Id == 0)
            {
                procedimento = new Procedimento(request.Nome);
            }
            else
            {
                procedimento = await _repository.GetProcedimentoByIdAsync(clinica, request.Id);

                if (procedimento == null)
                    throw new Exception("Procedimento não encontrado");

                procedimento.Alterar(request.Nome);
            }

            var id = await _repository.SalvarProcedimentoAsync(clinica, procedimento);

            return id;
        }
    }
}

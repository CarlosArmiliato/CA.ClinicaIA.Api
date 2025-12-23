using MediatR;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Application.Gerenciamento.Pacientes.Commands;

namespace CA.ClinicaIA.Application.Gerenciamento.Pacientes.Handlers
{
    public class SalvarPacienteHandler : IRequestHandler<SalvarPacienteCommand, int>
    {
        private readonly IClinicaRepository _repository;

        public SalvarPacienteHandler(IClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(SalvarPacienteCommand request, CancellationToken cancellationToken)
        {
            var clinica = await _repository.GetClinicaByIdAsync(request.ClinicaId);

            if (clinica == null)
                throw new Exception("Clinica não encontrada");

            Paciente? paciente;

            if (request.Id != 0)
            {
                paciente = new Paciente(
                    request.Nome,
                    request.DataNascimento,
                    request.Cpf,
                    request.CarteirinhaConvenio,
                    request.NomeResponsavel,
                    request.DocumentoResponsavel,
                    request.TelefoneResponsavel,
                    request.EmailResponsavel);
            }
            else
            {
                paciente = await _repository.GetPacienteByIdAsync(clinica, request.Id);

                if (paciente == null)
                    throw new Exception("Paciente não encontrada");

                paciente.Alterar(
                    request.Nome,
                    request.DataNascimento,
                    request.Cpf,
                    request.CarteirinhaConvenio,
                    request.NomeResponsavel,
                    request.DocumentoResponsavel,
                    request.TelefoneResponsavel,
                    request.EmailResponsavel);
            }

            var id = await _repository.SalvarPacienteAsync(clinica, paciente);

            return id;

        }
    }
}

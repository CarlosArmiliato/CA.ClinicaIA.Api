using CA.ClinicaIA.Domain.Clinicas;
using CA.ClinicaIA.Domain.Prontuario;

namespace CA.ClinicaIA.Domain.Repositories
{
    public interface IProntuarioRepository
    {
        // Guia Methods
        Task SalvarGuiaAsync(Clinica clinica, Guia guia);
        Task<Guia?> GetGuiaByIdAsync(Clinica clinica, int id);

        // Agendamento Methods
        Task SalvarAgendamentoAsync(Clinica clinica, Agendamento agendamento);
        Task<Agendamento?> GetAgendamentoByIdAsync(Clinica clinica, int id);
    }
}

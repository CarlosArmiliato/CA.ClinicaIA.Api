using CA.ClinicaIA.Domain.Clinicas;

namespace CA.ClinicaIA.Domain.Repositories
{
    public interface IClinicaRepository
    {
        //Clinica Methods
        Task<int> SalvarClinicaAsync(Clinica clinica);
        Task<Clinica?> GetClinicaByIdAsync(int id);

        // Paciente Methods
        Task<int> SalvarPacienteAsync(Clinica clinica, Paciente paciente);
        Task<Paciente?> GetPacienteByIdAsync(Clinica clinica, int id);

        // Procedimento Methods
        Task SalvarProcedimentoAsync(Clinica clinica, Procedimento procedimento);
        Task<Procedimento?> GetProcedimentoByIdAsync(Clinica clinica, int id);

        // Profissional Methods
        Task SalvarProfissionalAsync(Clinica clinica, Profissional profissional);
        Task<Profissional?> GetProfissionalByIdAsync(Clinica clinica, int id);

        // Plano Methods
        Task SalvarPlanoAsync(Clinica clinica, Plano plano);
        Task<Plano?> GetPlanoByIdAsync(Clinica clinica, int id);
    }
}

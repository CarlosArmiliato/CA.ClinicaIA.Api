using CA.ClinicaIA.Dto.Dtos.Clinica;
using CA.ClinicaIA.Dto.Pagination;
using CA.ClinicaIA.Dto.Queries.Clinica.Requests;

namespace CA.ClinicaIA.Dto.Queries.Clinica
{
    public interface IClinicaQuery
    {
        //Clinica Methods
        Task<ClinicaDto?> GetClinicaByIdAsync(int id);
        Task<PagingResponse<ClinicaDto>> GetClinicasPagedAsync(ObterClinicasRequest request);

        // Paciente Methods
        Task<PacienteDto?> GetPacienteByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id);
        Task<PagingResponse<PacienteDto>> GetPacientesPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterPacientesRequest request);

        // Procedimento Methods
        Task<ProcedimentoDto?> GetProcedimentoByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id);
        Task<PagingResponse<ProcedimentoDto>> GetProcedimentosPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterProcedimentosRequest request);

        // Profissional Methods
        Task<ProfissionalDto?> GetProfissionalByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id);
        Task<PagingResponse<ProfissionalDto>> GetProfissionaisPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterProfissionaisRequest request);

        // Plano Methods
        Task<PlanoDto?> GetPlanoByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id);
        Task<PagingResponse<PlanoDto>> GetPlanosPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterPlanosRequest request);
    }
}

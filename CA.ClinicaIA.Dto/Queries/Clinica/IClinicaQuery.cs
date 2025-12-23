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
        Task<PacienteDto?> GetPacienteByIdAsync(int id);
        Task<PagingResponse<PacienteDto>> GetPacientesPagedAsync(ObterPacientesRequest request);

        // Procedimento Methods
        Task<ProcedimentoDto?> GetProcedimentoByIdAsync(int id);
        Task<PagingResponse<ProcedimentoDto>> GetProcedimentosPagedAsync(ObterProcedimentosRequest request);

        // Profissional Methods
        Task<ProfissionalDto?> GetProfissionalByIdAsync(int id);
        Task<PagingResponse<ProfissionalDto>> GetProfissionaisPagedAsync(ObterProfissionaisRequest request);
    }
}

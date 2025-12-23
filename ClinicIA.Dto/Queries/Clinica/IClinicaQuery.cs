using ClinicIA.Dto.Dtos.Clinica;
using ClinicIA.Dto.Pagination;
using ClinicIA.Dto.Queries.Clinica.Requests;

namespace ClinicIA.Dto.Queries.Clinica
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

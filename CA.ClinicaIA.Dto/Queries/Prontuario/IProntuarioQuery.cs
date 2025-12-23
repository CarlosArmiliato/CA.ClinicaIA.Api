using CA.ClinicaIA.Dto.Dtos.Prontuario;
using CA.ClinicaIA.Dto.Pagination;
using CA.ClinicaIA.Dto.Queries.Prontuario.Requests;

namespace CA.ClinicaIA.Dto.Queries.Prontuario
{
    public interface IProntuarioQuery
    {
        // Agendamento Methods
        Task<AgendamentoDto?> GetAgendamentoByIdAsync(int id);
        Task<PagingResponse<AgendamentoDto>> GetAgendamentosAsync(ObterAgendamentosRequest request);

        // Guia Methods
        Task<GuiaDto?> GetGuiaByIdAsync(int id);
        Task<PagingResponse<GuiaDto>> GetGuiasAsync(ObterGuiasRequest request);
    }
}

using ClinicIA.Dto.Dtos.Prontuario;
using ClinicIA.Dto.Pagination;
using ClinicIA.Dto.Queries.Prontuario.Requests;

namespace ClinicIA.Dto.Queries.Prontuario
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

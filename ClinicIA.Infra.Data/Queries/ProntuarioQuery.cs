using ClinicIA.Infra.Data.Context;
using ClinicIA.Dto.Queries.Prontuario;
using ClinicIA.Dto.Dtos.Prontuario;
using ClinicIA.Dto.Pagination;
using ClinicIA.Dto.Queries.Prontuario.Requests;

namespace ClinicIA.Infra.Data.Queries
{
    public class ProntuarioQuery : IProntuarioQuery
    {
        private readonly ClinicIAContext _context;

        public ProntuarioQuery(ClinicIAContext context)
        {
            _context = context;
        }

        public Task<AgendamentoDto?> GetAgendamentoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponse<AgendamentoDto>> GetAgendamentosAsync(ObterAgendamentosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GuiaDto?> GetGuiaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponse<GuiaDto>> GetGuiasAsync(ObterGuiasRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

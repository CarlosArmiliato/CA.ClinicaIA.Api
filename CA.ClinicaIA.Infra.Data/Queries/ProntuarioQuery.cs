using CA.ClinicaIA.Infra.Data.Context;
using CA.ClinicaIA.Dto.Queries.Prontuario;
using CA.ClinicaIA.Dto.Dtos.Prontuario;
using CA.ClinicaIA.Dto.Pagination;
using CA.ClinicaIA.Dto.Queries.Prontuario.Requests;

namespace CA.ClinicaIA.Infra.Data.Queries
{
    public class ProntuarioQuery : IProntuarioQuery
    {
        private readonly ClinicaIAContext _context;

        public ProntuarioQuery(ClinicaIAContext context)
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

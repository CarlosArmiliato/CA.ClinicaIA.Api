using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Prontuario.Requests
{
    public class ObterGuiasRequest : PagingRequest
    {
        public int? PacienteId { get; set; }
        public int? PlanoId { get; set; }
    }
}

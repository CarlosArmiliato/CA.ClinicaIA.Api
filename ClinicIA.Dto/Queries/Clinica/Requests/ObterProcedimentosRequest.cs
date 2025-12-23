using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Clinica.Requests
{
    public class ObterProcedimentosRequest : PagingRequest
    {
        public string? Nome { get; set; }
        public int? ClinicaId { get; set; }
    }
}

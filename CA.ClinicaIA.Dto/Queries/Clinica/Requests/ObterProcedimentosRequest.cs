using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.Dto.Queries.Clinica.Requests
{
    public class ObterProcedimentosRequest : PagingRequest
    {
        public string? Nome { get; set; }
        public int? ClinicaId { get; set; }
    }
}

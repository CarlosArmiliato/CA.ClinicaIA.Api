using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.Dto.Queries.Clinica.Requests
{
    public class ObterPlanosRequest : PagingRequest
    {
        public string? Nome { get; set; }
    }
}

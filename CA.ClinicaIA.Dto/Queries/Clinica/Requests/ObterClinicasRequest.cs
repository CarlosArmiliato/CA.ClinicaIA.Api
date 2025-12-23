using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.Dto.Queries.Clinica.Requests
{
    public class ObterClinicasRequest : PagingRequest
    {
        public string? Nome { get; set; }
    }
}

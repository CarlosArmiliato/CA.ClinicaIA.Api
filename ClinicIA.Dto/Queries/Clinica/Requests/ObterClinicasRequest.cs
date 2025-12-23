using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Clinica.Requests
{
    public class ObterClinicasRequest : PagingRequest
    {
        public string? Nome { get; set; }
    }
}

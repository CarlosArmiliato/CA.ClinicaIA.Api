using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Clinica.Requests
{
    public class ObterPlanosRequest : PagingRequest
    {
        public string? Nome { get; set; }
    }
}

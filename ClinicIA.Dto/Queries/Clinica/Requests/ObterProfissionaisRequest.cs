using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Clinica.Requests
{
    public class ObterProfissionaisRequest : PagingRequest
    {
        public string? Nome { get; set; }
        public int? ClinicaId { get; set; }
    }
}

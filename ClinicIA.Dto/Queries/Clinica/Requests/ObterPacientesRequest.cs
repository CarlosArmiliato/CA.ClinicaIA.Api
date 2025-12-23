using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Clinica.Requests
{
    public class ObterPacientesRequest : PagingRequest
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public int? ClinicaId { get; set; }
    }
}

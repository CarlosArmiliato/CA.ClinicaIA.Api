using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.Dto.Queries.Prontuario.Requests
{
    public class ObterGuiasRequest : PagingRequest
    {
        public int? PacienteId { get; set; }
        public int? PlanoId { get; set; }
    }
}

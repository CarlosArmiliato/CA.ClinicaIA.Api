using System;
using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.Dto.Queries.Prontuario.Requests
{
    public class ObterAgendamentosRequest : PagingRequest
    {
        public DateTime? Data { get; set; }
        public int? ProfissionalId { get; set; }
        public int? PacienteId { get; set; }
    }
}

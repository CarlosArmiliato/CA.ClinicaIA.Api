using System;
using ClinicIA.Dto.Pagination;

namespace ClinicIA.Dto.Queries.Prontuario.Requests
{
    public class ObterAgendamentosRequest : PagingRequest
    {
        public DateTime? Data { get; set; }
        public int? ProfissionalId { get; set; }
        public int? PacienteId { get; set; }
    }
}

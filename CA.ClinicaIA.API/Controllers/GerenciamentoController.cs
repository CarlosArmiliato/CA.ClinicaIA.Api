using Microsoft.AspNetCore.Mvc;
using MediatR;
using CA.ClinicaIA.Application.Gerenciamento.Clinicas.Commands;
using CA.ClinicaIA.Dto.Queries.Clinica;
using CA.ClinicaIA.Dto.Dtos.Clinica;
using CA.ClinicaIA.Dto.Queries.Clinica.Requests;

namespace CA.ClinicaIA.API.Controllers
{
    [ApiController]
    [Route("api/gerenciamento")]
    public class GerenciamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClinicaQuery _clinicaQuery;

        public GerenciamentoController(IMediator mediator, IClinicaQuery clinicaQuery)
        {
            _mediator = mediator;
            _clinicaQuery = clinicaQuery;
        }

        #region Clinica
        [HttpPost("clinicas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateClinica([FromBody] SalvarClinicaCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("clinicas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdateClinicaById(int id, [FromBody] SalvarClinicaCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("clinicas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClinicaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ClinicaDto))]
        public async Task<IActionResult> GetClinicaById(int id)
        {
            var clinica = await _clinicaQuery.GetClinicaByIdAsync(id);

            return Ok(clinica);
        }

        [HttpGet("clinicas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClinicaDto>))]
        public async Task<IActionResult> GetAllClinicas([FromQuery] ObterClinicasRequest request)
        {
            var clinica = await _clinicaQuery.GetClinicasPagedAsync(request);

            return Ok(clinica);
        }
        #endregion
    }
}

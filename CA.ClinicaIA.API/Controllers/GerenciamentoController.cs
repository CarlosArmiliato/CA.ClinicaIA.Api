using Microsoft.AspNetCore.Mvc;
using MediatR;
using CA.ClinicaIA.Application.Gerenciamento.Clinicas.Commands;
using CA.ClinicaIA.Dto.Queries.Clinica;
using CA.ClinicaIA.Dto.Dtos.Clinica;
using CA.ClinicaIA.Dto.Queries.Clinica.Requests;
using CA.ClinicaIA.Application.Gerenciamento.Pacientes.Commands;

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

        #region Paciente
        [HttpPost("pacientes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreatePaciente([FromBody] SalvarPacienteCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("pacientes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdatePacienteById(int id, [FromBody] SalvarPacienteCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("pacientes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PacienteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PacienteDto))]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            var paciente = await _clinicaQuery.GetPacienteByIdAsync(id);

            return Ok(paciente);
        }

        [HttpGet("pacientes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PacienteDto>))]
        public async Task<IActionResult> GetAllPacientes([FromQuery] ObterPacientesRequest request)
        {
            var paciente = await _clinicaQuery.GetPacientesPagedAsync(request);

            return Ok(paciente);
        }
        #endregion
    }
}

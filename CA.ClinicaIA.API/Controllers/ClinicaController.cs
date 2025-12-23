using Microsoft.AspNetCore.Mvc;
using MediatR;
using CA.ClinicaIA.Dto.Queries.Clinica;
using CA.ClinicaIA.Dto.Dtos.Clinica;
using CA.ClinicaIA.Dto.Queries.Clinica.Requests;
using CA.ClinicaIA.Application.Gerenciamento.Pacientes.Commands;
using CA.ClinicaIA.Application.Gerenciamento.Planos.Commands;
using CA.ClinicaIA.Application.Gerenciamento.Profissionais.Commands;
using CA.ClinicaIA.Application.Gerenciamento.Procedimentos.Commands;
using CA.ClinicaIA.Dto.Pagination;

namespace CA.ClinicaIA.API.Controllers
{
    [ApiController]
    [Route("api/clinica")]
    public class ClinicaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClinicaQuery _clinicaQuery;

        public ClinicaController(IMediator mediator, IClinicaQuery clinicaQuery)
        {
            _mediator = mediator;
            _clinicaQuery = clinicaQuery;
        }

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<PacienteDto>))]
        public async Task<IActionResult> GetAllPacientes([FromQuery] ObterPacientesRequest request)
        {
            var paciente = await _clinicaQuery.GetPacientesPagedAsync(request);

            return Ok(paciente);
        }
        #endregion

        #region Plano
        [HttpPost("planos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreatePlano([FromBody] SalvarPlanoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("planos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdatePlanoById(int id, [FromBody] SalvarPlanoCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("planos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlanoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PlanoDto))]
        public async Task<IActionResult> GetPlanoById(int id)
        {
            var plano = await _clinicaQuery.GetPlanoByIdAsync(id);

            return Ok(plano);
        }

        [HttpGet("planos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<PlanoDto>))]
        public async Task<IActionResult> GetAllPlanos([FromQuery] ObterPlanosRequest request)
        {
            var planos = await _clinicaQuery.GetPlanosPagedAsync(request);

            return Ok(planos);
        }
        #endregion

        #region Profissional
        [HttpPost("profissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateProfissional([FromBody] SalvarProfissionalCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("profissionais/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdateProfissionalById(int id, [FromBody] SalvarProfissionalCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("profissionais/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfissionalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProfissionalDto))]
        public async Task<IActionResult> GetProfissionalById(int id)
        {
            var profissional = await _clinicaQuery.GetProfissionalByIdAsync(id);

            return Ok(profissional);
        }

        [HttpGet("profissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<ProfissionalDto>))]
        public async Task<IActionResult> GetAllProfissionais([FromQuery] ObterProfissionaisRequest request)
        {
            var profissionais = await _clinicaQuery.GetProfissionaisPagedAsync(request);

            return Ok(profissionais);
        }
        #endregion

        #region Procedimento
        [HttpPost("procedimentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateProcedimento([FromBody] SalvarProcedimentoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("procedimentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdateProcedimentoById(int id, [FromBody] SalvarProcedimentoCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("procedimentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProcedimentoDto))]
        public async Task<IActionResult> GetProcedimentoById(int id)
        {
            var procedimento = await _clinicaQuery.GetProcedimentoByIdAsync(id);

            return Ok(procedimento);
        }

        [HttpGet("procedimentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<ProcedimentoDto>))]
        public async Task<IActionResult> GetAllProcedimentos([FromQuery] ObterProcedimentosRequest request)
        {
            var procedimentos = await _clinicaQuery.GetProcedimentosPagedAsync(request);

            return Ok(procedimentos);
        }
        #endregion
    }
}

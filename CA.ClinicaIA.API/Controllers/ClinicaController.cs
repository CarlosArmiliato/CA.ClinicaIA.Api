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

using CA.ClinicaIA.Domain.Repositories;

namespace CA.ClinicaIA.API.Controllers
{
    [ApiController]
    [Route("api/clinica/{clinicaId}")]
    public class ClinicaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClinicaQuery _clinicaQuery;
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaController(IMediator mediator, IClinicaQuery clinicaQuery, IClinicaRepository clinicaRepository)
        {
            _mediator = mediator;
            _clinicaQuery = clinicaQuery;
            _clinicaRepository = clinicaRepository;
        }

        #region Paciente
        [HttpPost("pacientes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreatePaciente(int clinicaId, [FromBody] SalvarPacienteCommand command)
        {
            command.ClinicaId = clinicaId;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("pacientes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdatePacienteById(int clinicaId, int id, [FromBody] SalvarPacienteCommand command)
        {
            command.ClinicaId = clinicaId;
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("pacientes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PacienteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PacienteDto))]
        public async Task<IActionResult> GetPacienteById(int clinicaId, int id)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            var paciente = await _clinicaQuery.GetPacienteByIdAsync(clinica, id);

            return Ok(paciente);
        }

        [HttpGet("pacientes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<PacienteDto>))]
        public async Task<IActionResult> GetAllPacientes(int clinicaId, [FromQuery] ObterPacientesRequest request)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            request.ClinicaId = clinicaId;
            var paciente = await _clinicaQuery.GetPacientesPagedAsync(clinica, request);

            return Ok(paciente);
        }
        #endregion

        #region Plano
        [HttpPost("planos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreatePlano(int clinicaId, [FromBody] SalvarPlanoCommand command)
        {
            command.ClinicaId = clinicaId;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("planos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdatePlanoById(int clinicaId, int id, [FromBody] SalvarPlanoCommand command)
        {
            command.ClinicaId = clinicaId;
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("planos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlanoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PlanoDto))]
        public async Task<IActionResult> GetPlanoById(int clinicaId, int id)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            var plano = await _clinicaQuery.GetPlanoByIdAsync(clinica, id);

            return Ok(plano);
        }

        [HttpGet("planos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<PlanoDto>))]
        public async Task<IActionResult> GetAllPlanos(int clinicaId, [FromQuery] ObterPlanosRequest request)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            var planos = await _clinicaQuery.GetPlanosPagedAsync(clinica, request);

            return Ok(planos);
        }
        #endregion

        #region Profissional
        [HttpPost("profissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateProfissional(int clinicaId, [FromBody] SalvarProfissionalCommand command)
        {
            command.ClinicaId = clinicaId;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("profissionais/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdateProfissionalById(int clinicaId, int id, [FromBody] SalvarProfissionalCommand command)
        {
            command.ClinicaId = clinicaId;
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("profissionais/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfissionalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProfissionalDto))]
        public async Task<IActionResult> GetProfissionalById(int clinicaId, int id)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            var profissional = await _clinicaQuery.GetProfissionalByIdAsync(clinica, id);

            return Ok(profissional);
        }

        [HttpGet("profissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<ProfissionalDto>))]
        public async Task<IActionResult> GetAllProfissionais(int clinicaId, [FromQuery] ObterProfissionaisRequest request)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            request.ClinicaId = clinicaId;
            var profissionais = await _clinicaQuery.GetProfissionaisPagedAsync(clinica, request);

            return Ok(profissionais);
        }
        #endregion

        #region Procedimento
        [HttpPost("procedimentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateProcedimento(int clinicaId, [FromBody] SalvarProcedimentoCommand command)
        {
            command.ClinicaId = clinicaId;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("procedimentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> UpdateProcedimentoById(int clinicaId, int id, [FromBody] SalvarProcedimentoCommand command)
        {
            command.ClinicaId = clinicaId;
            command.Id = id;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("procedimentos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProcedimentoDto))]
        public async Task<IActionResult> GetProcedimentoById(int clinicaId, int id)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            var procedimento = await _clinicaQuery.GetProcedimentoByIdAsync(clinica, id);

            return Ok(procedimento);
        }

        [HttpGet("procedimentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagingResponse<ProcedimentoDto>))]
        public async Task<IActionResult> GetAllProcedimentos(int clinicaId, [FromQuery] ObterProcedimentosRequest request)
        {
            var clinica = await _clinicaRepository.GetClinicaByIdAsync(clinicaId);
            if (clinica == null) return NotFound("Clinica não encontrada");

            request.ClinicaId = clinicaId;
            var procedimentos = await _clinicaQuery.GetProcedimentosPagedAsync(clinica, request);

            return Ok(procedimentos);
        }
        #endregion
    }
}

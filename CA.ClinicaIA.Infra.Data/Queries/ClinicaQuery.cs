using Microsoft.EntityFrameworkCore;
using CA.ClinicaIA.Infra.Data.Context;
using CA.ClinicaIA.Dto.Queries.Clinica;
using CA.ClinicaIA.Dto.Dtos.Clinica;
using CA.ClinicaIA.Dto.Pagination;
using CA.ClinicaIA.Dto.Queries.Clinica.Requests;

namespace CA.ClinicaIA.Infra.Data.Queries
{
    public class ClinicaQuery : IClinicaQuery
    {
        private readonly ClinicaIAContext _context;

        public ClinicaQuery(ClinicaIAContext context)
        {
            _context = context;
        }
        public async Task<ClinicaDto?> GetClinicaByIdAsync(int id)
        {
            return await (from c in _context.Clinicas
                          where c.Id == id
                          select new ClinicaDto
                          {
                              Id = c.Id,
                              Nome = c.Nome,
                              Configuracoes = c.Configuracoes
                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<PagingResponse<ClinicaDto>> GetClinicasPagedAsync(ObterClinicasRequest request)
        {
            var query = _context.Clinicas.AsQueryable();

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(p => p.Nome.Contains(request.Nome));

            var total = await query.CountAsync();

            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new ClinicaDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Configuracoes = c.Configuracoes
                })
                .ToListAsync();

            return new PagingResponse<ClinicaDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRecords = total,
                Data = data
            };
        }

        // --- Paciente Methods ---
        public async Task<PacienteDto?> GetPacienteByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id)
        {
            return await (from p in _context.Pacientes
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new PacienteDto
                          {
                              Id = p.Id,
                              Nome = p.Nome,
                              DataNascimento = p.DataNascimento,
                              Cpf = p.Cpf,
                              CarteirinhaConvenio = p.CarteirinhaConvenio,
                              NomeResponsavel = p.NomeResponsavel,
                              DocumentoResponsavel = p.DocumentoResponsavel,
                              TelefoneResponsavel = p.TelefoneResponsavel,
                              EmailResponsavel = p.EmailResponsavel,
                              GoogleContactId = p.GoogleContactId,

                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<PagingResponse<PacienteDto>> GetPacientesPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterPacientesRequest request)
        {
            var query = _context.Pacientes.AsQueryable();

            query = query.Where(p => p.ClinicaId == clinica.Id);

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(p => p.Nome.Contains(request.Nome));

            if (!string.IsNullOrEmpty(request.Cpf))
                query = query.Where(p => p.Cpf!.Contains(request.Cpf));

            if (request.ClinicaId.HasValue)
                query = query.Where(p => p.ClinicaId == request.ClinicaId.Value);

            var total = await query.CountAsync();

            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new PacienteDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento,
                    Cpf = p.Cpf,
                    CarteirinhaConvenio = p.CarteirinhaConvenio,
                    NomeResponsavel = p.NomeResponsavel,
                    DocumentoResponsavel = p.DocumentoResponsavel,
                    TelefoneResponsavel = p.TelefoneResponsavel,
                    EmailResponsavel = p.EmailResponsavel,
                    GoogleContactId = p.GoogleContactId,

                })
                .ToListAsync();

            return new PagingResponse<PacienteDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRecords = total,
                Data = data
            };
        }

        // --- Procedimento Methods ---
        public async Task<ProcedimentoDto?> GetProcedimentoByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id)
        {
            return await (from p in _context.Procedimentos
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new ProcedimentoDto
                          {
                              Id = p.Id,
                              Nome = p.Nome,

                              ProcedimentoPlanos = p.ProcedimentoPlanos
                                .Select(x => new ProcedimentoPlanoDto
                                {
                                    Id = x.Id,
                                    ValorCoparticipacao = x.ValorCoparticipacao,
                                    ValorProcedimento = x.ValorProcedimento,
                                    Plano = new PlanoDto
                                    {
                                        Id = x.Plano.Id,
                                        Nome = x.Plano.Nome,
                                        Intercambio = x.Plano.Intercambio
                                    }
                                }).ToList()
                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<PagingResponse<ProcedimentoDto>> GetProcedimentosPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterProcedimentosRequest request)
        {
            var query = _context.Procedimentos.AsQueryable();

            query = query.Where(p => p.ClinicaId == clinica.Id);

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(p => p.Nome.Contains(request.Nome));

            if (request.ClinicaId.HasValue)
                query = query.Where(p => p.ClinicaId == request.ClinicaId.Value);

            var total = await query.CountAsync();

            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProcedimentoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,

                    ProcedimentoPlanos = p.ProcedimentoPlanos
                                .Select(x => new ProcedimentoPlanoDto
                                {
                                    Id = x.Id,
                                    ValorCoparticipacao = x.ValorCoparticipacao,
                                    ValorProcedimento = x.ValorProcedimento,
                                    Plano = new PlanoDto
                                    {
                                        Id = x.Plano.Id,
                                        Nome = x.Plano.Nome,
                                        Intercambio = x.Plano.Intercambio
                                    }
                                }).ToList()
                })
                .ToListAsync();

            return new PagingResponse<ProcedimentoDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRecords = total,
                Data = data
            };
        }

        // --- Profissional Methods ---
        public async Task<ProfissionalDto?> GetProfissionalByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id)
        {
            return await (from p in _context.Profissionais
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new ProfissionalDto
                          {
                              Id = p.Id,
                              Nome = p.Nome,
                              Email = p.Email,
                              GoogleAccountId = p.GoogleAccountId,

                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<PagingResponse<ProfissionalDto>> GetProfissionaisPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterProfissionaisRequest request)
        {
            var query = _context.Profissionais.AsQueryable();

            query = query.Where(p => p.ClinicaId == clinica.Id);

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(p => p.Nome.Contains(request.Nome));
            if (request.ClinicaId.HasValue)
                query = query.Where(p => p.ClinicaId == request.ClinicaId.Value);

            var total = await query.CountAsync();
            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProfissionalDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Email = p.Email,
                    GoogleAccountId = p.GoogleAccountId,

                })
                .ToListAsync();

            return new PagingResponse<ProfissionalDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRecords = total,
                Data = data
            };
        }

        // --- Plano Methods ---
        public async Task<PlanoDto?> GetPlanoByIdAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, int id)
        {
            return await (from p in _context.Planos
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new PlanoDto
                          {
                              Id = p.Id,
                              Nome = p.Nome,
                              Intercambio = p.Intercambio
                          })
                          .FirstOrDefaultAsync();
        }

        public async Task<PagingResponse<PlanoDto>> GetPlanosPagedAsync(CA.ClinicaIA.Domain.Clinicas.Clinica clinica, ObterPlanosRequest request)
        {
            var query = _context.Planos.AsQueryable();

            query = query.Where(p => p.ClinicaId == clinica.Id);

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(p => p.Nome.Contains(request.Nome));

            var total = await query.CountAsync();

            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new PlanoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Intercambio = p.Intercambio
                })
                .ToListAsync();

            return new PagingResponse<PlanoDto>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRecords = total,
                Data = data
            };
        }
    }
}

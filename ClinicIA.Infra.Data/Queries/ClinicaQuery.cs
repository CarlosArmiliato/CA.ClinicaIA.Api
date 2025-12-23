using Microsoft.EntityFrameworkCore;
using ClinicIA.Infra.Data.Context;
using ClinicIA.Dto.Queries.Clinica;
using ClinicIA.Dto.Dtos.Clinica;
using ClinicIA.Dto.Pagination;
using ClinicIA.Dto.Queries.Clinica.Requests;

namespace ClinicIA.Infra.Data.Queries
{
    public class ClinicaQuery : IClinicaQuery
    {
        private readonly ClinicIAContext _context;

        public ClinicaQuery(ClinicIAContext context)
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
        public async Task<PacienteDto?> GetPacienteByIdAsync(int id)
        {
            return await (from p in _context.Pacientes
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

        public async Task<PagingResponse<PacienteDto>> GetPacientesPagedAsync(ObterPacientesRequest request)
        {
            var query = _context.Pacientes.AsQueryable();

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
        public async Task<ProcedimentoDto?> GetProcedimentoByIdAsync(int id)
        {
            return await (from p in _context.Procedimentos
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

        public async Task<PagingResponse<ProcedimentoDto>> GetProcedimentosPagedAsync(ObterProcedimentosRequest request)
        {
            var query = _context.Procedimentos.AsQueryable();

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
        public async Task<ProfissionalDto?> GetProfissionalByIdAsync(int id)
        {
            return await (from p in _context.Profissionais
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

        public async Task<PagingResponse<ProfissionalDto>> GetProfissionaisPagedAsync(ObterProfissionaisRequest request)
        {
            var query = _context.Profissionais.AsQueryable();

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
    }
}

using Microsoft.EntityFrameworkCore;
using CA.ClinicaIA.Infra.Data.Context;
using CA.ClinicaIA.Infra.Data.Tables;
using CA.ClinicaIA.Domain.Repositories;
using CA.ClinicaIA.Domain.Clinicas;

namespace CA.ClinicaIA.Infra.Data.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicaIAContext _context;

        public ClinicaRepository(ClinicaIAContext context)
        {
            _context = context;
        }

        #region Clinica
        public async Task<int> SalvarClinicaAsync(Clinica clinica)
        {
            var entity = new ClinicaTable
            {
                Id = clinica.Id,
                Nome = clinica.Nome,
                Configuracoes = clinica.Configuracoes
            };

            if (clinica.Id == 0)
            {
                entity.CreatedAt = DateTimeOffset.Now;
                await _context.Clinicas.AddAsync(entity);
            }
            else
            {
                var entry = _context.Entry(entity);

                entry.Property(x => x.Nome).IsModified = true;
                entry.Property(x => x.Configuracoes).IsModified = true;
                entity.UpdatedAt = DateTimeOffset.Now;
            }

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Clinica?> GetClinicaByIdAsync(int id)
        {
            return await (from c in _context.Clinicas
                          where c.Id == id
                          select new Clinica(c.Id, c.Nome, c.Configuracoes))
                          .FirstOrDefaultAsync();
        }

        #endregion

        #region Paciente
        public async Task<int> SalvarPacienteAsync(Clinica clinica, Paciente paciente)
        {
            var entity = new PacienteTable
            {
                ClinicaId = clinica.Id,
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Cpf = paciente.Cpf,
                CarteirinhaConvenio = paciente.CarteirinhaConvenio,
                NomeResponsavel = paciente.NomeResponsavel,
                DocumentoResponsavel = paciente.DocumentoResponsavel,
                TelefoneResponsavel = paciente.TelefoneResponsavel,
                EmailResponsavel = paciente.EmailResponsavel,
                GoogleContactId = paciente.GoogleContactId,
            };

            if (clinica.Id == 0)
            {
                entity.CreatedAt = DateTimeOffset.Now;
                await _context.Pacientes.AddAsync(entity);
            }
            else
            {
                var entry = _context.Entry(entity);

                entry.Property(x => x.Nome).IsModified = true;
                entry.Property(x => x.DataNascimento).IsModified = true;
                entry.Property(x => x.Cpf).IsModified = true;
                entry.Property(x => x.CarteirinhaConvenio).IsModified = true;
                entry.Property(x => x.NomeResponsavel).IsModified = true;
                entry.Property(x => x.DocumentoResponsavel).IsModified = true;
                entry.Property(x => x.TelefoneResponsavel).IsModified = true;
                entry.Property(x => x.EmailResponsavel).IsModified = true;
                entry.Property(x => x.GoogleContactId).IsModified = true;
                entity.UpdatedAt = DateTimeOffset.Now;
            }

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Paciente?> GetPacienteByIdAsync(Clinica clinica, int id)
        {
            return await (from p in _context.Pacientes
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new Paciente(
                              p.Id,
                              p.Nome,
                              p.DataNascimento,
                              p.Cpf,
                              p.CarteirinhaConvenio,
                              p.NomeResponsavel,
                              p.DocumentoResponsavel,
                              p.TelefoneResponsavel,
                              p.EmailResponsavel,
                              p.GoogleContactId))
                          .FirstOrDefaultAsync();
        }

        #endregion

        #region Procedimentos
        public async Task<int> SalvarProcedimentoAsync(Clinica clinica, Procedimento procedimento)
        {
            ProcedimentoTable? table;
            if (procedimento.Id == 0)
            {
                table = new ProcedimentoTable
                {
                    ClinicaId = clinica.Id,
                    Nome = procedimento.Nome,
                    CreatedAt = DateTimeOffset.Now
                };
                await _context.Procedimentos.AddAsync(table);
            }
            else
            {
                table = await _context.Procedimentos.FindAsync(procedimento.Id);
                if (table != null)
                {
                    table.Nome = procedimento.Nome;
                    table.UpdatedAt = DateTimeOffset.Now;
                }
            }
            await _context.SaveChangesAsync();
            return table?.Id ?? 0;
        }

        public async Task<Procedimento?> GetProcedimentoByIdAsync(Clinica clinica, int id)
        {
            return await (from p in _context.Procedimentos
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new Procedimento(
                            p.Id,
                            p.Nome,
                            p.ProcedimentoPlanos.Select(x => new ProcedimentoPlano(x.Id,
                                new Plano(x.Plano.Id,
                                    x.Plano.Nome,
                                    x.Plano.Intercambio),
                                x.ValorCoparticipacao,
                                x.ValorProcedimento)).ToList()))
                          .FirstOrDefaultAsync();
        }
        #endregion

        #region Profissional
        public async Task<int> SalvarProfissionalAsync(Clinica clinica, Profissional profissional)
        {
            ProfissionalTable? table;
            if (profissional.Id == 0)
            {
                table = new ProfissionalTable
                {
                    ClinicaId = clinica.Id,
                    Nome = profissional.Nome,
                    Email = profissional.Email,
                    GoogleAccountId = profissional.GoogleAccountId,
                    CreatedAt = DateTimeOffset.Now
                };
                await _context.Profissionais.AddAsync(table);
            }
            else
            {
                table = await _context.Profissionais.FindAsync(profissional.Id);
                if (table != null)
                {
                    table.Nome = profissional.Nome;
                    table.Email = profissional.Email;
                    table.GoogleAccountId = profissional.GoogleAccountId;
                    table.UpdatedAt = DateTimeOffset.Now;
                }
            }
            await _context.SaveChangesAsync();
            return table?.Id ?? 0;
        }

        public async Task<Profissional?> GetProfissionalByIdAsync(Clinica clinica, int id)
        {
            return await (from p in _context.Profissionais
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new Profissional(p.Id, p.Nome, p.Email, p.GoogleAccountId))
                          .FirstOrDefaultAsync();
        }

        #endregion

        #region Plano
        public async Task<int> SalvarPlanoAsync(Clinica clinica, Plano entity)
        {
            PlanoTable? table;
            if (entity.Id == 0)
            {
                table = new PlanoTable
                {
                    ClinicaId = clinica.Id,
                    Nome = entity.Nome,
                    Intercambio = entity.Intercambio,
                    CreatedAt = DateTimeOffset.Now
                };
                await _context.Planos.AddAsync(table);
            }
            else
            {
                table = await _context.Planos.FindAsync(entity.Id);
                if (table != null)
                {
                    table.Nome = entity.Nome;
                    table.Intercambio = entity.Intercambio;
                    table.UpdatedAt = DateTimeOffset.Now;
                }
            }
            await _context.SaveChangesAsync();
            return table?.Id ?? 0;
        }

        public async Task<Plano?> GetPlanoByIdAsync(Clinica clinica, int id)
        {
            return await (from p in _context.Planos
                          where p.ClinicaId == clinica.Id
                          where p.Id == id
                          select new Plano(p.Id, p.Nome, p.Intercambio))
                          .FirstOrDefaultAsync();
        }


        #endregion
    }
}

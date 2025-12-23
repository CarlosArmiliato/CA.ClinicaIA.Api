using Microsoft.EntityFrameworkCore;
using ClinicIA.Infra.Data.Context;
using ClinicIA.Infra.Data.Tables;
using ClinicIA.Domain.Repositories;
using ClinicIA.Domain.Prontuario;
using ClinicIA.Domain.Clinicas;

namespace ClinicIA.Infra.Data.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ClinicIAContext _context;

        public ProntuarioRepository(ClinicIAContext context)
        {
            _context = context;
        }

        #region Guias
        public async Task SalvarGuiaAsync(Clinica clinica, Guia entity)
        {
            if (entity.Id == 0)
            {
                var table = new GuiaTable
                {
                    ClinicaId = clinica.Id,
                    Numero = entity.Numero,
                    PacienteId = entity.Paciente.Id,
                    PlanoId = entity.Plano.Id,
                    Procedimentos = []
                };
                await _context.Guias.AddAsync(table);
            }
            else
            {
                var table = await _context.Guias.FindAsync(entity.Id);
                if (table != null)
                {
                    table.Numero = entity.Numero;
                    table.PacienteId = entity.Paciente.Id;
                    table.PlanoId = entity.Plano.Id;
                    table.UpdatedAt = System.DateTime.UtcNow;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Guia?> GetGuiaByIdAsync(Clinica clinica, int id)
        {
            return await (from g in _context.Guias
                          where g.Id == id
                          select new Guia(g.Id,
                            g.Numero,
                            new PacienteResumo(g.Paciente.Id, g.Paciente.Nome),
                            new Plano(g.Plano.Id, g.Plano.Nome, g.Plano.Intercambio)))
                          .FirstOrDefaultAsync();
        }

        #endregion

        #region Agendamentos
        public async Task SalvarAgendamentoAsync(Clinica clinica, Agendamento domain)
        {
            if (domain.Id == 0)
            {
                var table = new AgendamentoTable
                {
                    ClinicaId = clinica.Id,
                    DataHora = domain.DataHora,
                    Status = domain.Status,
                    Tipo = domain.Tipo,
                    ProfissionalId = domain.Profissional.Id,
                    PacienteId = domain.Paciente.Id,
                    ProcedimentoId = domain.Procedimento.Id,
                    GoogleEventId = domain.GoogleEventId,
                    LancamentosFinanceiros = []
                };
                await _context.Agendamentos.AddAsync(table);
            }
            else
            {
                var table = await _context.Agendamentos.FindAsync(domain.Id);
                if (table != null)
                {
                    table.DataHora = domain.DataHora;
                    table.Status = domain.Status;
                    table.Tipo = domain.Tipo;
                    table.ProfissionalId = domain.Profissional.Id;
                    table.PacienteId = domain.Paciente.Id;
                    table.ProcedimentoId = domain.Procedimento.Id;
                    table.GoogleEventId = domain.GoogleEventId;
                    table.UpdatedAt = DateTime.UtcNow;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Agendamento?> GetAgendamentoByIdAsync(Clinica clinica, int id)
        {
            return await (from a in _context.Agendamentos
                          where a.Id == id
                          select new Agendamento(
                              a.Id,
                              a.DataHora,
                              a.Status,
                              a.Tipo,
                              a.GoogleEventId,
                              new ProfissionalResumo(a.Profissional.Id, a.Profissional.Nome),
                              new PacienteResumo(a.Paciente.Id, a.Paciente.Nome),
                              new ProcedimentoResumo(a.Procedimento.Id, a.Procedimento.Nome)))
                          .FirstOrDefaultAsync();
        }
        #endregion
    }
}

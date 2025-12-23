using System;
using System.Collections.Generic;
using ClinicIA.Domain.Clinicas;

namespace ClinicIA.Domain.Prontuario
{
    public class Guia
    {
        public int Id { get; }
        public string Numero { get; private set; }

        public virtual PacienteResumo Paciente { get; private set; }
        public virtual Plano Plano { get; private set; }

        public Guia(string numero, PacienteResumo paciente, Plano plano)
        {
            Numero = numero;
            Paciente = paciente;
            Plano = plano;
        }

        public Guia(int id, string numero, PacienteResumo paciente, Plano plano)
            : this(numero, paciente, plano)
        {
            Id = id;
        }
    }
}

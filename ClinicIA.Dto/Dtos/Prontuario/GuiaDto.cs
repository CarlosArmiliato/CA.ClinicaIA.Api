namespace ClinicIA.Dto.Dtos.Prontuario
{
    public class GuiaDto
    {
        public required int Id { get; set; }
        public required string Numero { get; set; }
        public required PacienteDto Paciente { get; set; }
        public required PlanoDto Plano { get; set; }
    }
}

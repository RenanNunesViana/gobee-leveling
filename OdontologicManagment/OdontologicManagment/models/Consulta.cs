using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace OdontologicManagment.models
{
    public class Consulta
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public int ClienteId { get; init; }

        [ForeignKey("ClienteId")]
        public Client Cliente { get; init; }

        [Required]
        public DateTime DataConsulta { get; init; }

        [Required]
        public TimeSpan HoraInicial { get; init; }

        [Required]
        public TimeSpan HoraFinal { get; init; }

        public Consulta(Client cliente, String dataConsulta, String horaInicial, String horaFinal)
        {
            if (!DateTime.TryParseExact(dataConsulta, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                throw new ArgumentException("Data de nascimento inválida. Use o formato DDMMAAAA.");
            }

            if (!TimeSpan.TryParseExact(horaInicial, "hhmm", CultureInfo.InvariantCulture, TimeSpanStyles.None, out var parsedHoraInicial))
            {
                throw new ArgumentException("Hora inicial inválida. Use o formato HHMM.");
            }

            if (!TimeSpan.TryParseExact(horaFinal, "hhmm", CultureInfo.InvariantCulture, TimeSpanStyles.None, out var parsedHoraFinal))
            {
                throw new ArgumentException("Hora final inválida. Use o formato HHMM.");
            }

            if (parsedHoraFinal <= parsedHoraInicial)
            {
                throw new ArgumentException("Hora final deve ser maior que a hora inicial.");
            }

            if (!IsValidTime(parsedHoraInicial) || !IsValidTime(parsedHoraFinal))
            {
                throw new ArgumentException("Horas devem estar em intervalos de 15 minutos.");
            }

            if(IsTempoValido(parsedHoraInicial, parsedHoraFinal))
            {
                throw new ArgumentException("Horário de agendamento fora do horário de funcionamento (08:00 - 19:00).");
            }

            var now = DateTime.Now;
            if (parsedDate < now.Date || (parsedDate == now.Date && parsedHoraInicial <= now.TimeOfDay))
            {
                throw new ArgumentException("A consulta deve ser agendada para um período futuro.");
            }



            Cliente = cliente;
            ClienteId = cliente.Id;
            DataConsulta = parsedDate;
            HoraInicial = parsedHoraInicial;
            HoraFinal = parsedHoraFinal;
        }

        // construtor para mapeamento do EF core
        private Consulta(Client cliente, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal) { }

        private bool IsValidTime(TimeSpan time)
        {
            return time.Minutes % 15 == 0;
        }

        private bool IsTempoValido(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            var horaAbertura = new TimeSpan(8, 0, 0);
            var horaTermino = new TimeSpan(19, 0, 0);

            return horaInicial >= horaAbertura && horaFinal <= horaTermino;
            
        }

    }
}

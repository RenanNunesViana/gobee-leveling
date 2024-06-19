using OdontologicManagment.utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


            var dataFormatada = Utilities.FormataDataConsulta(dataConsulta, "ddMMyyyy");

            var horaInicialFormatada = Utilities.FormataHoraConsulta(horaInicial, "hhmm");

            var horaFinalFormatada = Utilities.FormataHoraConsulta(horaFinal, "hhmm");

            if (horaFinalFormatada <= horaInicialFormatada)
            {
                throw new ArgumentException("Hora final deve ser maior que a hora inicial.");
            }

            if (!IsValidTime(horaInicialFormatada) || !IsValidTime(horaFinalFormatada))
            {
                throw new ArgumentException("Horas devem estar em intervalos de 15 minutos.");
            }

            if (!IsTempoValido(horaInicialFormatada, horaFinalFormatada))
            {
                throw new ArgumentException("Horário de agendamento fora do horário de funcionamento (08:00 - 19:00).");
            }

            var now = DateTime.Now;
            if (dataFormatada < now.Date || (dataFormatada == now.Date && horaInicialFormatada <= now.TimeOfDay))
            {
                throw new ArgumentException("A consulta deve ser agendada para um período futuro.");
            }



            Cliente = cliente;
            ClienteId = cliente.Id;
            DataConsulta = dataFormatada;
            HoraInicial = horaInicialFormatada;
            HoraFinal = horaFinalFormatada;
        }

        // construtor para mapeamento do EF core
        public Consulta() { }

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

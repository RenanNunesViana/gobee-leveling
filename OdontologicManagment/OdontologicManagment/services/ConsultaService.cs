using OdontologicManagment.models;
using OdontologicManagment.repositories;
using OdontologicManagment.repository;
using System.Globalization;

namespace OdontologicManagment.services
{
    public class ConsultaService
    {
        private ConsultaRepo _consultaRepo;
        private ClientRepo _clientRepo;
        public ConsultaService(ApplicationDbContext context) {
            _consultaRepo = new ConsultaRepo(context);
            _clientRepo = new ClientRepo(context);
        }

        public Consulta AgendarConsulta(String cpf, String dia, String inicio, String termino)
        {

            Client client = _clientRepo.FindByCpf(cpf) ?? throw new ArgumentException("Erro: paciente não cadastrado");
            Consulta consulta = new(client, dia, inicio, termino);

            if (IsSobreposta(consulta))
            {
                throw new ArgumentException("Erro: já existe uma consulta agendada nesse horário");
            }
            return _consultaRepo.Save(consulta);
        }

        public List<Consulta> FindByCpfConsultasFuturas(String cpf)
        {
            List<Consulta> consultas = _consultaRepo.FindByCpf(cpf);
            var consultasFuturas = consultas.Where(
                c => c.DataConsulta > DateTime.Now.Date
                    ||
                    (c.DataConsulta == DateTime.Now.Date && c.HoraInicial > DateTime.Now.TimeOfDay)
                ).ToList();

            return consultasFuturas;
        }

        public List<Consulta> FindConsultasEntreDatas(DateTime inicio, DateTime termino)
        {
            return _consultaRepo.FindAllBetweenDate(inicio, termino);
        }

        internal List<Consulta> FindConsultas()
        {
            return _consultaRepo.FindAll();
        }

        public bool CancelarConsulta(string cpf, string dataConsulta, string horaInicial)
        {
            if (!DateTime.TryParseExact(dataConsulta, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDataConsulta))
            {
                throw new ArgumentException("Data de consulta inválida. Use o formato DDMMAAAA.");
            }

            if (!TimeSpan.TryParseExact(horaInicial, "hhmm", CultureInfo.InvariantCulture, out var parsedHoraInicial))
            {
                throw new ArgumentException("Hora inicial inválida. Use o formato HHMM.");
            }

            var consulta = _consultaRepo.FindByCpfAndDateAndTime(cpf, parsedDataConsulta, parsedHoraInicial) ?? throw new Exception("Erro: agendamento não encontrado");

            var now = DateTime.Now;
            if (consulta.DataConsulta < now.Date || (consulta.DataConsulta == now.Date && consulta.HoraInicial <= now.TimeOfDay))
            {
                throw new ArgumentException("O cancelamento só pode ser realizado para agendamentos futuros.");
            }

            return _consultaRepo.DeleteConsulta(consulta);
        }

        private bool IsSobreposta(Consulta consulta)
        {
            List<Consulta> consultas = _consultaRepo.FindAll();

            return consultas.Any(c =>
                c.DataConsulta == consulta.DataConsulta &&
                ((consulta.HoraInicial >= c.HoraInicial && consulta.HoraInicial < c.HoraFinal) ||
                 (consulta.HoraFinal > c.HoraInicial && consulta.HoraFinal <= c.HoraFinal)));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OdontologicManagment.models;
using OdontologicManagment.repositories;
using OdontologicManagment.repository;

namespace OdontologicManagment.services
{
    internal class ConsultaService
    {
        private ConsultaRepo _consultaRepo;
        private ClientRepo _clientRepo;
        public ConsultaService(ApplicationDbContext context) {
            _consultaRepo = new ConsultaRepo(context);
            _clientRepo = new ClientRepo(context);
        }

        public Consulta agendarConsulta(String cpf, String dia, String inicio, String termino)
        {

            Client client = _clientRepo.FindByCpf(cpf) ?? throw new ArgumentException("Cliente com este cpf não registrado");
            Consulta consulta = new(client, dia, inicio, termino);

            if (IsSobreposta(consulta))
            {
                throw new ArgumentException("Já existe uma consulta agendada neste período.");
            }
            return _consultaRepo.Save(consulta);
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

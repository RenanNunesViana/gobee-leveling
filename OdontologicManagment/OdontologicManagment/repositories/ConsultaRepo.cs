using OdontologicManagment.models;

namespace OdontologicManagment.repositories
{
    public class ConsultaRepo
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepo(ApplicationDbContext context)
        {
            _context = context;

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            // Procura por clientes
            if (_context.Clients.Any())
            {
                return;   //O BD foi alimentado
            }

            _context.SaveChanges();
        }

        public Consulta Save(Client client, String dia, String inicio, String termino)
        {

            var novaConsulta = new Consulta(client, dia, inicio, termino);

            _context.Consultas.Add(novaConsulta);
            _context.SaveChanges();
            return novaConsulta;
        }

        public Consulta Save(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return consulta;
        }

        public List<Consulta> FindByCpf(String cpf)
        {
            List<Consulta> consultas = _context.Consultas.Where(c => c.Cliente.Cpf == cpf).ToList();
            return consultas;
        }

        public List<Consulta> FindAll()
        {
            return [.. _context.Consultas];
        }

        public Consulta? FindByCpfAndDateAndTime(String cpf, DateTime data, TimeSpan horaInicio)
        {
            var consulta = _context.Consultas.FirstOrDefault(c =>
                c.Cliente.Cpf == cpf &&
                c.DataConsulta == data &&
                c.HoraInicial == horaInicio);
            return consulta;
        }

        public List<Consulta> FindAllBetweenDate(DateTime inicio, DateTime final)
        {
            var consultas = _context.Consultas.Where(c => c.DataConsulta >= inicio && c.DataConsulta <= final);
            return [.. consultas];
        }

        public bool DeleteConsulta(Consulta consulta)
        {
            if (_context.Consultas.Find(consulta) != null)
            {
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}

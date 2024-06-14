using OdontologicManagment.models;

namespace OdontologicManagment.repositories
{
    public class ConsultaRepo
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Consulta Save(Client client, String dia, String inicio, String termino)
        {

            var novaConsulta = new Consulta(client,dia,inicio,termino);

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

    }
}

using Microsoft.EntityFrameworkCore;
using OdontologicManagment.models;
using MySql.Data.MySqlClient;
using OdontologicManagment.repositories;

namespace OdontologicManagment.repository
{
    public class ClientRepo
    {     

        private readonly ApplicationDbContext _context;

        public ClientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Save(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public bool ClientExists(string cpf)
        {
            return _context.Clients.Any(c => c.Cpf == cpf);
        }

        public List<Client> FindAll()
        {
            return [.. _context.Clients];
        }

        public Client? FindByCpf(string cpf)
        {
            return _context.Clients.SingleOrDefault(client => client.Cpf == cpf);
        }

        public Client? FindById(int id)
        {
            return _context.Clients.SingleOrDefault(client => client.Id == id);
        }

        public Client? DeleteByCpf(string cpf)
        {
            Client? client = FindByCpf(cpf);
            if (client == null)
            {
                return null;
            }
            else
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return client;
            }
        }

    }

}


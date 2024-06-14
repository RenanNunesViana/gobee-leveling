using OdontologicManagment.repository;
using OdontologicManagment.models;
using OdontologicManagment.repositories;

namespace OdontologicManagment.services
{
    internal class ClientService
    {

        private readonly ClientRepo _repo;

        public ClientService(ApplicationDbContext context)
        {
            _repo = new ClientRepo(context);
            //_repo.Initialize();
        }


        public Client ResgatarClientePeloId(int id)
        {
            Client? client = _repo.FindById(id);
            if (client != null)
            {
                return client;
            }
            else
            {
                throw new Exception($"Cliente com id {id} não encontrado.");
            }
        }

        public Client? ResgatarClientePeloCpf(String cpf)
        {
            var client = _repo.FindByCpf(cpf);
            if (client != null)
            {
                return client;
            }
            else { throw new Exception($"Cliente com cpf {cpf} não encontrado!"); }
        }

        public void AddClient(Client client)
        {
            // Acho que talvez seja desnecessário pois o DbSet já impede IDs iguais. Pus por desencargo de consciência
            if (_repo.FindById(client.Id) == null)
            {
                LancaExcecaoCpfExistente(client.Cpf);
                _repo.Save(client);
                Console.WriteLine("Cliente adicionado com sucesso.");
            }
            else
            {
                throw new Exception("Cliente com este ID já existe!");
            }
        }

        private void LancaExcecaoCpfExistente(String cpf)
        {
            
            if (_repo.ClientExists(cpf)) 
                throw new ArgumentException("Cliente com este cpf já consta no sistema");
            
        }
    }
}

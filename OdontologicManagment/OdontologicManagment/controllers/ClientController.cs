using OdontologicManagment.models;
using OdontologicManagment.repository;

namespace OdontologicManagment.controllers
{
    public class ClientController
    {
        private readonly ClientRepo _repo;

        public ClientController()
        {
            _repo = new ClientRepo();
            InicializaBD.Initialize(_repo);
        }


        public void ResgatarCliente(int id)
        {
            Client? client = _repo.Clients.Find(id);
            if (client != null)
            {
                //TODO exibição do cliente
            }
            else
            {
                Console.WriteLine($"Cliente com id {id} não encontrado.");
            }
        }

        public void AddClient(Client client)
        {

            if (_repo.Clients.Find(client.Id) == null)
            {
                LancaExcecaoCpfExistente(client.Cpf);
                _repo.Clients.Add(client);
                _repo.SaveChanges();
                Console.WriteLine("Cliente adicionado com sucesso.");
            }
            else
            {
                throw new Exception("Cliente com este ID já existe!");
            }
        }

        private void LancaExcecaoCpfExistente(String cpf)
        {
            foreach (var client in _repo.Clients)
            {
                if (client.Cpf == cpf) throw new ArgumentException("Cliente com este cpf já consta no sistema");
            }
        }
    }
}

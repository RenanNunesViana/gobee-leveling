using OdontologicManagment.models;
using OdontologicManagment.repositories;
using OdontologicManagment.services;

namespace OdontologicManagment.controllers
{
    public class ClientController
    {

        private readonly ClientService clientService;

        public ClientController(ApplicationDbContext context)
        {
            clientService = new ClientService(context);
        }

        public void AddClient(Client client)
        {
            try
            {
                clientService.AddClient(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void recuperaClientById(int id)
        {
            return;
        }
    }
}

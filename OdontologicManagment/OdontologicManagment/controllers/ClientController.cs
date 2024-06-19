using OdontologicManagment.models;
using OdontologicManagment.repositories;
using OdontologicManagment.services;
using OdontologicManagment.views;

namespace OdontologicManagment.controllers
{
    public class ClientController
    {

        private readonly ClientService clientService;

        public ClientController(ApplicationDbContext context)
        {
            clientService = new ClientService(context);
        }

        public int InicializarMenuClientes()
        {
            var menu = new CadastroCliente();
            var resposta = menu.InitMenu();
            return resposta;
        }

        public void AddClient()
        {
            try
            {
                RegistrarCliente.Run(out string? cpf, out string? nome, out string? birthDate);
                var dataNascimentoFormatada = birthDate?.Replace("/", "");
                Console.WriteLine(dataNascimentoFormatada);
                clientService.AddClient(new(nome, cpf, dataNascimentoFormatada));
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n");
        }

        public void DeleteClient()
        {
            try
            {
                Console.WriteLine("CPF: ");
                var cpf = Console.ReadLine();
                clientService.RmvClientByCpf(cpf);
                Console.WriteLine("Paciente excluído com sucesso!");
            }
            catch (Exception ex) {Console.WriteLine(ex.Message);}
            Console.WriteLine("\n");
        }

        public void recuperaClientById(int id)
        {
            return;
        }

        
        public void RecuperarClientes(int ordenacao)
        {
            var clientes = clientService.RecuperaClientes(ordenacao);
            ListagemClientes.Run(clientes);
            Console.WriteLine("\n");
        }
    }
}

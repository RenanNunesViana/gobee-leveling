using OdontologicManagment.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.controllers
{
    public class ControleDeFluxo()
    {

        public static void Run(MenuController menuController, ClientController clientController, ConsultaController consultaController)
        {
            MenuPrincipal(menuController, clientController, consultaController);
        }

        private static void MenuPrincipal(MenuController menuController, ClientController clientController, ConsultaController consultaController)
        {
            int primeiraInteracao = menuController.InicializaMenuPrincipal();

            switch (primeiraInteracao)
            {
                case 1:
                    var escolhaCliente = clientController.InicializarMenuClientes();
                    EscolheuCliente(escolhaCliente, menuController, clientController, consultaController);
                    break;
                case 2:
                    var escolhaConsulta = consultaController.InicializaMenuConsulta();
                    EscolheuConsulta(escolhaConsulta, menuController, clientController, consultaController);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida.");
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
            }
        }

        private static void EscolheuCliente(int escolhaNoMenuDeCliente, MenuController menuController, ClientController clientController, ConsultaController consultaController)
        {
            switch (escolhaNoMenuDeCliente)
            {
                case 1:
                    clientController.AddClient();
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 2:

                    clientController.DeleteClient();
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 3:
                    clientController.RecuperarClientes(0);
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 4:
                    clientController.RecuperarClientes(1);
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 5:
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                default:
                    Console.WriteLine("Por favor, insira um valor válido");
                    EscolheuCliente(escolhaNoMenuDeCliente, menuController, clientController, consultaController);
                    break;
            }
        }

        private static void EscolheuConsulta(int escolhaNoMenuDeConsulta, MenuController menuController, ClientController clientController, ConsultaController consultaController)
        {
            switch (escolhaNoMenuDeConsulta)
            {
                case 1:
                    consultaController.AgendamentoConsulta();
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 2:
                    consultaController.CancelamentoConsulta();
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 3:
                    consultaController.ResgatarConsultas();
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                case 4:
                    MenuPrincipal(menuController, clientController, consultaController);
                    break;
                default:
                    Console.WriteLine("Por favor, insira um valor válido");
                    EscolheuConsulta(escolhaNoMenuDeConsulta, menuController, clientController, consultaController);
                    break;
            }
        }
    }
}

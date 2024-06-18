using OdontologicManagment.models;
using OdontologicManagment.repositories;
using OdontologicManagment.services;
using OdontologicManagment.views;

namespace OdontologicManagment.controllers
{
    public class ConsultaController
    {
        private readonly ConsultaService consultaService;

        public ConsultaController(ApplicationDbContext context)
        {
            consultaService = new ConsultaService(context);
        }

        public int InicializaMenuConsulta()
        {
            var menu = new CadastroConsulta();
            var resposta = menu.InitMenu();
            return resposta;
        }

        /*public void AddConsulta(string cpf, string dia, string inicio, string termino)
        {
            try
            {
                consultaService.AgendarConsulta(cpf, dia, inicio, termino);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ResgataConsultasEntreDatas(DateTime inicio, DateTime termino)
        {
            try
            {
                var consultas = consultaService.FindConsultasEntreDatas(inicio, termino);
                ListagemConsultas.Run(consultas);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }*/

        public void ResgatarConsultas()
        {
            try
            {
                var consultas = consultaService.FindConsultas();
                ListagemConsultas.Run(consultas);
            } catch (Exception ex) { Console.WriteLine(ex.Message); };
        }

        public void AgendamentoConsulta()
        {
            try
            {
                RegistrarConsulta.Run(out string? cpf, out string? data, out string? inicio, out string? termino);
                consultaService.AgendarConsulta(cpf, data, inicio, termino);
                Console.WriteLine("Agendamento realizado com sucesso!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void CancelamentoConsulta()
        {

            try
            {
                Console.WriteLine("CPF: ");
                var cpf = Console.ReadLine();
                Console.WriteLine("Data da consulta: ");
                var data = Console.ReadLine();
                Console.WriteLine("Hora inicial: ");
                var hora = Console.ReadLine();

                consultaService.CancelarConsulta(cpf, data, hora);

                Console.WriteLine("Agendamento cancelado com sucesso!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}

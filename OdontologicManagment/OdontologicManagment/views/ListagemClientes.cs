using OdontologicManagment.models;

namespace OdontologicManagment.views
{
    public class ListagemClientes
    {
        public ListagemClientes()
        {
        }

        public static void Run(List<Client> clientes)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("CPF          Nome                        Dt.Nasc.      Idade");
            Console.WriteLine("------------------------------------------------------------");
            foreach (Client client in clientes)
            {
                Console.WriteLine($"{client.Cpf} {client.Name} {client.BirthDate.Date} {client.CalcularIdade()}");
                var consultasFuturas = client.RetornaConsultasFuturas();
                if (consultasFuturas.Count > 0)
                {
                    foreach (Consulta consulta in consultasFuturas)
                    {
                        Console.WriteLine($"Agendado para: {consulta.DataConsulta.Date}");
                        Console.WriteLine($"{consulta.HoraInicial} às {consulta.HoraFinal}");
                    }
                }
            }
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}

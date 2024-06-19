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
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("CPF                         Nome                                   Dt.Nasc.                     Idade");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            foreach (Client client in clientes)
            {
                Console.WriteLine($"{client.Cpf.PadRight(27)} {client.Name.PadRight(38)} {client.BirthDate.Date.ToString("dd/MM/yyyy")} {client.CalcularIdade().ToString().PadLeft(23)}");
                var consultasFuturas = client.RetornaConsultasFuturas();
                if (consultasFuturas.Count > 0)
                {
                    foreach (Consulta consulta in consultasFuturas)
                    {
                        Console.WriteLine($"                            Agendado para: {consulta.DataConsulta.Date.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"                            {consulta.HoraInicial.ToString(@"hh\:mm")} às {consulta.HoraFinal.ToString(@"hh\:mm")}");
                    }
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
    }
}

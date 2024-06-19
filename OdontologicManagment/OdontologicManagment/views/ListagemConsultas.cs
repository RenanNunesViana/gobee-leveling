using OdontologicManagment.models;
using OdontologicManagment.utils;

namespace OdontologicManagment.views
{
    public class ListagemConsultas
    {
        public ListagemConsultas() { }

        public static void Run(List<Consulta> consultas)
        {
            String? opcao;
            bool entradaErrada = true;

            do
            {
                Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
                opcao = Console.ReadLine()?.ToUpper();

                switch (opcao)
                {
                    case "P":
                        Console.WriteLine("Data Inicial: ");
                        String? dataInicial = Console.ReadLine();
                        if (dataInicial == null)
                        {
                            Console.WriteLine("Por favor ensira uma data no formato dd/MM/yyyy");
                            break;
                        }

                        Console.WriteLine("Data Final: ");
                        String? dataFinal = Console.ReadLine();
                        if (dataFinal == null)
                        {
                            Console.WriteLine("Por favor ensira uma data no formato dd/MM/yyyy");
                            break;
                        }
                        var consultasFiltradas = FiltrarConsultasPorData(consultas, dataInicial, dataFinal);
                        RetornaConsultasTemplate(consultasFiltradas);
                        entradaErrada = false;
                        break;
                    case "T":
                        RetornaConsultasTemplate(consultas);
                        entradaErrada = false;
                        break;
                    default:
                        Console.WriteLine("Por favor, insira T para listar toda a agenda ou P para determinar um periodo");
                        break;
                }

            }
            while (entradaErrada);

        }

        private static void RetornaConsultasTemplate(List<Consulta> consultas)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("   Data          H.Ini             H.Fim             Tempo              Nome               Dt.Nasc. ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (var consulta in consultas)
            {
                Console.WriteLine($"{consulta.DataConsulta.Date.ToString("dd/MM/yyyy")} {consulta.HoraInicial.ToString(@"hh\:mm").PadLeft(11)} {consulta.HoraFinal.ToString(@"hh\:mm").PadLeft(17)} {(consulta.HoraFinal - consulta.HoraInicial).ToString(@"hh\:mm").PadLeft(17)} {consulta.Cliente.Name.PadLeft(18)} {consulta.Cliente.BirthDate.Date.ToString("dd/MM/yyyy").PadLeft(22)}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }

        private static List<Consulta> FiltrarConsultasPorData(List<Consulta> consultas, String dataInicial, String dataFinal)
        {
            var dataInicialFormatada = Utilities.FormataDataConsulta(dataInicial, "ddMMyyyy");

            var dataFinalFormatada = Utilities.FormataDataConsulta(dataFinal, "ddMMyyyy");

            List<Consulta> consultasFiltradas = consultas.Where(c => c.DataConsulta.Date >= dataInicialFormatada && c.DataConsulta.Date <= dataFinalFormatada).ToList();
            return consultasFiltradas;

        }
    }
}

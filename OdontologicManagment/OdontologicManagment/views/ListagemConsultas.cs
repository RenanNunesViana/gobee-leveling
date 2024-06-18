using Google.Protobuf;
using OdontologicManagment.models;
using System.Globalization;
using System;

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
                Console.WriteLine($"Apresentar a agenda T-Toda ou P-Periodo: {opcao = Console.ReadKey().ToString()}");

                switch (opcao)
                {
                    case "P":
                        String? dataInicial;
                        Console.WriteLine($"Data Inicial: {dataInicial = Console.ReadLine()}");
                        if (dataInicial == null)
                        {
                            Console.WriteLine("Por favor ensira uma data no formato dd/MM/yyyy");
                            break;
                        }

                        String? dataFinal;
                        Console.WriteLine($"Data Final: {dataFinal = Console.ReadLine()}");
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
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("   Data    H.Ini    H.Fim    Tempo   Nome           Dt.Nasc. ");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var consulta in consultas)
            {
                Console.WriteLine($"{consulta.DataConsulta.Date} {consulta.HoraInicial} {consulta.HoraFinal} {consulta.HoraFinal - consulta.HoraInicial} {consulta.Cliente.Name} {consulta.Cliente.BirthDate.Date}");
            }
        }

        private static List<Consulta> FiltrarConsultasPorData(List<Consulta> consultas, String dataInicial, String dataFinal)
        {
                if(!DateTime.TryParseExact(dataInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDataInicial))
            {
                throw new Exception($"Utilize a data no formato dd/MM/yyyy");
            }

                if(DateTime.TryParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDataFinal))
            {
                throw new Exception($"Utilize a data no formato dd/MM/yyyy");
            }
            
            List<Consulta> consultasFiltradas = consultas.Where(c => c.DataConsulta.Date >= parsedDataInicial && c.DataConsulta.Date <= parsedDataFinal).ToList();//fazer a conversão das datas
            return consultasFiltradas;

        }
    }
}

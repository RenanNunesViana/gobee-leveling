namespace OdontologicManagment.views
{
    public class RegistrarConsulta
    {
        public static void Run(out String? cpf, out String? dataConsulta, out String? horaInicio, out String? horaTermino)
        {
            Console.WriteLine("CPF: ");
            cpf = Console.ReadLine();
            Console.WriteLine("Data da consulta: ");
            dataConsulta = Console.ReadLine();
            Console.WriteLine("Hora inicial: ");
            horaInicio = Console.ReadLine();
            Console.WriteLine("Hora final: ");
            horaTermino = Console.ReadLine();
        }
    }
}

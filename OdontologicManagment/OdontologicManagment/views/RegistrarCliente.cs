namespace OdontologicManagment.views
{
    internal class RegistrarCliente
    {
        public static void Run(out String? cpf, out String? nome, out String? birthDate)
        {
            Console.WriteLine("CPF: ");
            cpf = Console.ReadLine();
            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Data de nascimento: ");
            birthDate = Console.ReadLine();
        }
    }
}

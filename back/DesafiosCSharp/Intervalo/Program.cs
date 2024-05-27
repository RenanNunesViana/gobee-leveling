using IntervaloLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            // Criar intervalos de teste
            DateTime inicio1 = new DateTime(2024, 5, 27, 8, 0, 0);
            DateTime fim1 = new DateTime(2024, 5, 27, 17, 0, 0);
            Intervalo intervalo1 = new Intervalo(inicio1, fim1);

            DateTime inicio2 = new DateTime(2024, 5, 27, 12, 0, 0);
            DateTime fim2 = new DateTime(2024, 5, 27, 20, 0, 0);
            Intervalo intervalo2 = new Intervalo(inicio2, fim2);

            DateTime inicio3 = new DateTime(2024, 5, 28, 8, 0, 0);
            DateTime fim3 = new DateTime(2024, 5, 29, 17, 0, 0);
            Intervalo intervalo3 = new Intervalo(inicio3, fim3);

            // Exibir intervalos
            Console.WriteLine("Intervalos:");
            Console.WriteLine(intervalo1.ToString());
            Console.WriteLine(intervalo2.ToString());
            Console.WriteLine(intervalo3.ToString());

            // Verificar interseção entre intervalos
            Console.WriteLine("\nVerificação de Interseção:");
            Console.WriteLine($"Intervalo 1 tem interseção com Intervalo 2: {intervalo1.TemIntersecao(intervalo2)}");
            Console.WriteLine($"Intervalo 1 tem interseção com Intervalo 3: {intervalo1.TemIntersecao(intervalo3)}");
            Console.WriteLine($"Intervalo 2 tem interseção com Intervalo 3: {intervalo2.TemIntersecao(intervalo3)}");

            // Verificar igualdade entre intervalos
            Console.WriteLine("\nVerificação de Igualdade:");
            Console.WriteLine($"Intervalo 1 é igual a Intervalo 2: {intervalo1.Equals(intervalo2)}");
            Console.WriteLine($"Intervalo 1 é igual a Intervalo 3: {intervalo1.Equals(intervalo3)}");

            // Verificar duração dos intervalos
            Console.WriteLine("\nDuração dos Intervalos:");
            Console.WriteLine($"Duração do Intervalo 1: {intervalo1.Duracao}");
            Console.WriteLine($"Duração do Intervalo 2: {intervalo2.Duracao}");
            Console.WriteLine($"Duração do Intervalo 3: {intervalo3.Duracao}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
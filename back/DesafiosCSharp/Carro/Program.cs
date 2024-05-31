using CarroLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            // Criando motores
            Motor motor1 = new Motor(1.0);
            Motor motor2 = new Motor(1.6);
            Motor motor3 = new Motor(2.0);

            // Criando carros
            Carro carro1 = new Carro("ABC1234", "Modelo1", motor1);
            Carro carro2 = new Carro("XYZ5678", "Modelo2", motor2);

            Console.WriteLine(carro1);
            Console.WriteLine(carro2);

            // Tentativa de trocar motor
            carro1.Motor = motor3;
            Console.WriteLine(carro1);

            // Tentativa de usar o mesmo motor em outro carro
            try
            {
                carro2.Motor = motor3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            // Tentativa de criar carro sem motor
            try
            {
                Carro carro3 = new Carro("LMN9876", "Modelo3", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
namespace Vertice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vertice v1 = new(3.0f, 4.0f);
            Vertice v2 = new(3.0f, 4.0f);
            Vertice v3 = new(7.0f, 1.0f);

            Console.WriteLine($"Posição inicial: ({v1.X}, {v1.Y})");

            float distancia = v1.CalcularDistancia(v3);
            Console.WriteLine($"A distância em relação ao vértice ({v3.X}, {v3.Y}) é: {distancia}");

            v1.Move(7.0f, 1.0f);
            Console.WriteLine($"Nova posição: ({v1.X}, {v1.Y})");

            Console.WriteLine($"v1 é igual a v2? {v1.Equals(v2)}");
            Console.WriteLine($"v1 é igual a v3? {v1.Equals(v3)}");
        }
    }
}
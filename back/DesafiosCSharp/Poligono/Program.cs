using PoligonoLibrary;
using VerticeLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        // Criando vértices para o polígono
        Vertice v1 = new Vertice(0, 0);
        Vertice v2 = new Vertice(4, 0);
        Vertice v3 = new Vertice(4, 3);
        Vertice v4 = new Vertice(0, 3);

        try
        {
            Poligono poligono = new([v1, v2, v3, v4]);

            // Calculando e exibindo o perímetro do polígono
            float perimetro = poligono.CalcularPerimetro();
            Console.WriteLine($"Perímetro do polígono: {perimetro}");

            // Testando o método para adicionar um vértice
            Vertice v5 = new(2, 2);
            poligono.AddVertice(v5);
            Console.WriteLine($"Novo perímetro após adicionar um vértice: {poligono.CalcularPerimetro()}");

            // Testando o método para mover um vértice
            v5.Move(6, 2);
            Console.WriteLine($"Novo perímetro após mover um vértice: {poligono.CalcularPerimetro()}");

            Console.WriteLine($"Número de vértices iguais a: {poligono.Size}");

            // Testando o método para remover um vértice
            poligono.RemoveVertice(v5);
            Console.WriteLine($"Novo perímetro após remover um vértice: {poligono.CalcularPerimetro()}");

            Console.WriteLine($"Número de vértices iguais a: {poligono.Size}");

            // lançando erro/exception
            poligono.RemoveVertice(v4);
            poligono.RemoveVertice(v3);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
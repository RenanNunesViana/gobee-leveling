using TrianguloLibrary;
using VerticeLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        Vertice v1 = new Vertice(0, 0);
        Vertice v2 = new Vertice(3, 0);
        Vertice v3 = new Vertice(0, 4);

        Triangulo triangulo = new Triangulo(v1, v2, v3);

        // Testando métodos da classe
        Console.WriteLine($"Tipo do triângulo: {triangulo.Tipo}");
        Console.WriteLine($"Perímetro do triângulo: {triangulo.CalcularPerimetro()}");
        Console.WriteLine($"Área do triângulo: {triangulo.Area}");

        // Testando se dois triângulos são iguais
        Triangulo outroTriangulo = new Triangulo(new Vertice(1, 1), new Vertice(4, 1), new Vertice(1, 5));
        Triangulo outroTriangulo2 = new Triangulo(new Vertice(0, 0), new Vertice(0, 4), new Vertice(3, 0));
        Triangulo outroTriangulo3 = new Triangulo(new Vertice(1, 0), new Vertice(0, 4), new Vertice(3, 0));
        Console.WriteLine($"Os dois triângulos são iguais? {triangulo.Equals(outroTriangulo)}");
        Console.WriteLine($"Os dois triângulos são iguais? {triangulo.Equals(outroTriangulo2)}");
        Console.WriteLine($"Os dois triângulos são iguais? {triangulo.Equals(outroTriangulo3)}");
    }
}
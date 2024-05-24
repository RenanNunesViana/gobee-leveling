using Nivelamento.models;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var piramide = new Piramide(1);
            Console.WriteLine(piramide.Desenha());
        } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
    }
}
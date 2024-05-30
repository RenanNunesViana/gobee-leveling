using IntervaloLibrary;
using ListaIntervaloLibrary;

internal class Program
{
    private static void Main(string[] args)
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

        // Criando lista e adicionando Intervalos a lista
        ListaIntervalo lista = new();
        if(lista.Add(intervalo1)) Console.WriteLine($"intervalo {intervalo1} adicionado com sucesso!");
        if(lista.Add(intervalo2)) Console.WriteLine($"intervalo {intervalo2} adicionado com sucesso!");
        if(lista.Add(intervalo3)) Console.WriteLine($"intervalo {intervalo3} adicionado com sucesso!");

        // Mostrando readOnly intervalos na lista
        IReadOnlyList<Intervalo> listaRetornada = lista.Intervalos;
        Console.WriteLine("intervalos adicionados \n" + String.Join("\n", listaRetornada.Select(i => i.ToString())));

    }
}
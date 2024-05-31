using ExtensaoLista;

internal class Program
{
    private static void Main(string[] args)
    {
        // Testar com lista de inteiros
        List<int> intList = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
        intList.RemoveRepetidos();
        Console.WriteLine("Lista de inteiros sem repetidos: " + string.Join(", ", intList));

        // Testar com lista de strings
        List<string> stringList = new List<string> { "apple", "banana", "apple", "orange", "banana" };
        stringList.RemoveRepetidos();
        Console.WriteLine("Lista de strings sem repetidos: " + string.Join(", ", stringList));

        // Testar com lista de clientes
        List<Cliente> clienteList = new List<Cliente>
        {
            new Cliente("Renan", "12345678909"),
            new Cliente("Maria", "12345678909"), //deve ser removido
            new Cliente("João", "11144477735"), //deve ser removido
            new Cliente("Ana", "12345678909"),
            new Cliente("Carlos", "11144477735") //deve ser removido
        };
        clienteList.RemoveRepetidos();
        Console.WriteLine("Lista de clientes sem repetidos:");
        foreach (var cliente in clienteList)
        {
            Console.WriteLine(cliente);
        }

        // Testes de validação de CPF
        Console.WriteLine("\nTestes de validação de CPF:");
        string[] cpfsValidos = { "12345678909", "98765432100", "11144477735" };
        string[] cpfsInvalidos = { "12345678900", "12345678911", "00000000000" };

        Console.WriteLine("CPFs Válidos:");
        foreach (var cpf in cpfsValidos)
        {
            Console.WriteLine($"{cpf}: {clienteList[0].ValidarCPF(cpf)}");
        }

        Console.WriteLine("CPFs Inválidos:");
        foreach (var cpf in cpfsInvalidos)
        {
            Console.WriteLine($"{cpf}: {clienteList[0].ValidarCPF(cpf)}");
        }
    }
}
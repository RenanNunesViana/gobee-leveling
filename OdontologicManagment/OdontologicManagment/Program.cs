using OdontologicManagment.controllers;

using OdontologicManagment.models;

internal class Program
{
    private static void Main(string[] args)
    {

        ClientController controller = new();

        Client novoCliente = new("jorge", "98050446026", "30111995");

        Console.WriteLine($"adicionando novo cliente de cpf {novoCliente.Cpf} e nome {novoCliente.Name}");
        controller.AddClient(novoCliente);

    }
}
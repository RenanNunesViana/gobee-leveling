using OdontologicManagment.controllers;
using OdontologicManagment.repositories;
using OdontologicManagment.utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new ApplicationDbContext();

        MenuController menuController = new();
        ClientController clientController = new(context);
        ConsultaController consultaController = new(context);

        ControleDeFluxo.Run(menuController, clientController, consultaController);
    }

    

    
}
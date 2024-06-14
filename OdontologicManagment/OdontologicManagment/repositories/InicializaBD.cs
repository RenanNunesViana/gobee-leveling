using OdontologicManagment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.repository
{
    // deprecated/broked
    public static class InicializaBD
    {
        public static void Initialize(this ClientRepo repo)
        {
            repo._context.Database.EnsureDeleted();
            repo.Database.EnsureCreated();
            // Procura por clientes
            if (repo.Clients.Any())
            {
                return;   //O BD foi alimentado
            }
            var clients = new Client[]
            {
              new("Jorge W. Bush", "06607676430", "21101999"),
              new("Jorge W. Bush Jr.", "96451724033", "10022008"),
            };
            foreach (Client c in clients)
            {
                repo.Clients.Add(c);
            }
            repo.SaveChanges();
        }
    }
}

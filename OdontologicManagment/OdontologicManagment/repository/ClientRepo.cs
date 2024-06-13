using Microsoft.EntityFrameworkCore;
using OdontologicManagment.models;
using MySql.Data.MySqlClient;

namespace OdontologicManagment.repository
{
    public class ClientRepo : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conectionString = "Server=localhost;Port=3306;Database=dbclientes;Uid=root;Pwd=060263;";
                optionsBuilder.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
            }
        }

    }

}


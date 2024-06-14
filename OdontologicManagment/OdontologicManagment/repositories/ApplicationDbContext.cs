using Microsoft.EntityFrameworkCore;
using OdontologicManagment.models;

namespace OdontologicManagment.repositories
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public ApplicationDbContext()
        {
        }

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

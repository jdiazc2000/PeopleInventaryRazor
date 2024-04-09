using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PersonalContext : DbContext
    {
        public DbSet<PersonalEntity> TBPersonal { get; set; }

        //Configuración de la conexión
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=DESKTOP-CA5TT0R\\SQLEXPRESS; Database=Consolidado_Personal; user id=Julio; password=123; TrustServerCertificate=True");
            }
        }

        //Precargar datos en la Base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

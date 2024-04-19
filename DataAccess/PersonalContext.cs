using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PersonalContext : DbContext
    {
        public DbSet<PersonalEntity> TBPersonal { get; set; }
        public DbSet<DepartamentoEntity> ubigeo_peru_departments { get; set; }
        public DbSet<DistritosEntity> ubigeo_peru_districts { get; set; }
        public DbSet<ProvinciasEntity> ubigeo_peru_provinces { get; set; }
        public DbSet<RolesEntity> TBRoles { get; set; }
        public DbSet<TasasEntity> TBTasas { get; set; }
        public DbSet<EmpresasEntity> TBEmpresas { get; set; }
        public DbSet<CoordinadoresEntity> TBCoordinadores { get; set; }

        //Configuración de la conexión
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlServer("Server=DBPersonalIndra.mssql.somee.com; Database=DBPersonalIndra; user id=Sucrab_SQLLogin_2; password=egirdaohye; TrustServerCertificate=True");
                options.UseSqlServer("Server=24LAP5CD310JMXN; Database=Consolidado_Personal; user id=Julio; password=123; TrustServerCertificate=True");
            }
        }

        //Precargar datos en la Base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

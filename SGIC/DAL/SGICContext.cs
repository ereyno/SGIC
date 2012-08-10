using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SGIC.Models;

namespace SGIC.DAL
{
    public class SGICContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SGIC.Models.SGICContext>());

        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Dia> Dias { get; set; }
        public DbSet<Automovil> Automoviles { get; set; }
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Duenio> Duenios { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Quincena> Quincenas { get; set; }
        public DbSet<Semana> Semanas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<TipoTelefono> TipoTelefonos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

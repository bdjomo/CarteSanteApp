using Microsoft.EntityFrameworkCore;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarteSanteApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Archivage> Archives { get; set; }
        public DbSet<VClient> VClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Port explizit auf 5433 setzen                
                string connectionString = "Host=192.168.178.112;Port=5433;Database=CarteSanteElectronique;Username=postgres;Password=123";
                //tring connectionString = "Host=localhost;Port=5433;Database=CarteSanteElectronique;Username=postgres;Password=123";

                // Maps den C#-String/Enum direkt auf den PostgreSQL-Typ user_droit
                var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
                var dataSource = dataSourceBuilder.Build();

                // Übergeben der erstellten DataSource an UseNpgsql
                optionsBuilder.UseNpgsql(dataSource);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PostgreSQL ENUM-Typ 'user_droit' explizit zuweisen
            modelBuilder.Entity<User>()
                .Property(u => u.Droit)
                .HasColumnType("varchar(50)");
                //.HasColumnType("user_droit");

            // Rolle als int
            modelBuilder.Entity<User>()
                .Property(u => u.RoleId)
                .HasConversion<int>();

            // View als schlüssellos deklarieren und mappen
            modelBuilder.Entity<VClient>()
                .HasNoKey()
                .ToView("v_clients");
        }
    }
}

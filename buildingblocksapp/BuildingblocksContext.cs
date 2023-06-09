using buildingblocksapp.Models;
using Microsoft.EntityFrameworkCore;

namespace buildingblocksapp
{
    public class BuildingblocksContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public BuildingblocksContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Inkooporder> Inkooporders { get; set; } = null!;
        public DbSet<InkooporderCorrectie> InkooporderCorrecties { get; set; } = null!;
        public DbSet<Klantorder> Klantorders { get; set; } = null!;
        public DbSet<Orderpick> Orderpicks { get; set; } = null!;
        public DbSet<Werkorder> Werkorders { get; set; } = null!;
        public DbSet<Factuur> Facturen { get; set; } = null!;
        public DbSet<Betaling> Betalingen { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Factuur>().Navigation(e => e.Betalingen).AutoInclude();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Betaling)
                {
                    Betaling betaling = (Betaling)entry.Entity;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        betaling?.Factuur?.UpdateBetaalstatus();
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}

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
        public DbSet<Inkooporder> Inkooporders { get; set; }
        public DbSet<InkooporderCorrectie> InkooporderCorrecties { get; set; }
        public DbSet<Klantorder> Klantorders { get; set; }
        public DbSet<Orderpick> Orderpicks { get; set; }
        public DbSet<Werkorder> Werkorders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orderpick>().HasOne(wo => wo.Werkorder).WithOne(op => op.Orderpick).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

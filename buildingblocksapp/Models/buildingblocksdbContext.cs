using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace buildingblocksapp.Models
{
    public partial class buildingblocksdbContext : DbContext
    {
        public buildingblocksdbContext()
            : base("name=buildingblocksdbContext")
        {
        }

        public virtual DbSet<Inkooporder> Inkooporders { get; set; }
        public virtual DbSet<Klantorder> Klantorders { get; set; }
        public virtual DbSet<Orderpick> Orderpicks { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Werkorder> Werkorders { get; set; }
        public virtual DbSet<Inkoopordercorrectie> Inkoopordercorrecties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inkooporder>()
                .HasOptional(e => e.Inkoopordercorrectie)
                .WithRequired(e => e.Inkooporder);

            modelBuilder.Entity<Klantorder>()
                .Property(e => e.naam)
                .IsUnicode(false);

            modelBuilder.Entity<Klantorder>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Klantorder>()
                .Property(e => e.referentienummer)
                .IsUnicode(false);

            modelBuilder.Entity<Werkorder>()
                .Property(e => e.productielijn)
                .IsUnicode(false);
        }
    }
}

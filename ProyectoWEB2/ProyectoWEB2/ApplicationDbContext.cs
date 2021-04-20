using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProyectoWEB2
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direcciones>()
                .Property(e => e.Cedula)
                .IsFixedLength();

            modelBuilder.Entity<Personas>()
                .Property(e => e.Cedula)
                .IsFixedLength();

            modelBuilder.Entity<Personas>()
                .HasMany(e => e.Direcciones)
                .WithRequired(e => e.Personas)
                .WillCascadeOnDelete(false);
        }
    }
}

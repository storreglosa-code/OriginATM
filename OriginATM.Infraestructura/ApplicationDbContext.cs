using Microsoft.EntityFrameworkCore;
using OriginATM.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Infraestructura
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operacion>()
                .Property(o => o.Tipo)
                .HasConversion<string>();

            modelBuilder.Entity<Tarjeta>()
                .Property(t => t.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Operacion>()
                .Property(o => o.Monto)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Tarjeta>()
                .HasIndex(t => t.Numero)
                .IsUnique();
        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OriginATM.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Infraestructura
{
    public class ApplicacionDbContext : DbContext
    {
        public ApplicacionDbContext(DbContextOptions<ApplicacionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operacion>()
                .Property(o => o.Tipo)
                .HasConversion<int>();
        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
    }
}

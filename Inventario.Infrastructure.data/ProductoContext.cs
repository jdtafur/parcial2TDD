using Inventario.Core.Domain;
using Inventario.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Data
{
    public class ProductoContext : DbContextBase
    {
        public DbSet<Producto> Productos{ get; set; }

        public ProductoContext(DbContextOptions options) : base((options))
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasKey(c => c.Id);
            modelBuilder.Entity<Movimiento>().HasKey(c => c.Id);
        }
    }
}
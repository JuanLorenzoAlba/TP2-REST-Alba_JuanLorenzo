using Domain.Entities;
using Infrastructure.Config;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class RestaurantContext : DbContext
    {
        public DbSet<TipoMercaderia> TipoMercaderias { get; set; }
        public DbSet<Mercaderia> Mercaderias { get; set; }
        public DbSet<ComandaMercaderia> ComandasMercaderias { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<FormaEntrega> FormaEntregas { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoMercaderiaConfig());
            modelBuilder.ApplyConfiguration(new TipoMercaderiaData());

            modelBuilder.ApplyConfiguration(new MercaderiaConfig());
            modelBuilder.ApplyConfiguration(new MercaderiaData());

            modelBuilder.ApplyConfiguration(new ComandaMercaderiaConfig());

            modelBuilder.ApplyConfiguration(new ComandaConfig());

            modelBuilder.ApplyConfiguration(new FormaEntregaConfig());
            modelBuilder.ApplyConfiguration(new FormaEntregaData());
        }
    }
}

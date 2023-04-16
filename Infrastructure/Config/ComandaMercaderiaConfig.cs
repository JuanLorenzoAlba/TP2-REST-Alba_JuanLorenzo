using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ComandaMercaderiaConfig : IEntityTypeConfiguration<ComandaMercaderia>
    {
        public void Configure(EntityTypeBuilder<ComandaMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("ComandaMercaderia");
            entityBuilder.HasKey(e => new { e.MercaderiaId, e.ComandaId });

            entityBuilder.Property(m => m.ComandaMercaderiaId).ValueGeneratedOnAdd();

            entityBuilder.HasOne(d => d.Mercaderia)
            .WithMany(p => p.ComandasMercaderias)
            .HasForeignKey(d => d.MercaderiaId);

            entityBuilder.HasOne(d => d.Comanda)
            .WithMany(p => p.ComandasMercaderias)
            .HasForeignKey(d => d.ComandaId);
        }
    }
}

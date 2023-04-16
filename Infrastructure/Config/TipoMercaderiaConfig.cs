using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class TipoMercaderiaConfig : IEntityTypeConfiguration<TipoMercaderia>
    {
        public void Configure(EntityTypeBuilder<TipoMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("TipoMercaderia");
            entityBuilder.HasKey(e => e.TipoMercaderiaId);

            entityBuilder.Property(e => e.Descripcion)
            .HasMaxLength(50);

            entityBuilder.HasMany(t => t.Mercaderias)
            .WithOne(m => m.TipoMercaderia)
            .HasForeignKey(m => m.TipoMercaderiaId);
        }
    }
}

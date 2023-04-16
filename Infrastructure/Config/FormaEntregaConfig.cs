using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class FormaEntregaConfig : IEntityTypeConfiguration<FormaEntrega>
    {
        public void Configure(EntityTypeBuilder<FormaEntrega> entityBuilder)
        {
            entityBuilder.ToTable("FormaEntrega");
            entityBuilder.HasKey(e => e.FormaEntregaId);

            entityBuilder.Property(e => e.Descripcion)
            .HasMaxLength(50);

            entityBuilder.HasMany(t => t.Comandas)
            .WithOne(m => m.FormaEntrega)
            .HasForeignKey(m => m.FormaEntregaId);
        }
    }
}

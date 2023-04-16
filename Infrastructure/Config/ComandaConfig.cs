using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ComandaConfig : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> entityBuilder)
        {
            entityBuilder.ToTable("Comanda");
            entityBuilder.HasKey(e => e.ComandaId);

            entityBuilder.HasMany(m => m.ComandasMercaderias)
            .WithOne(cm => cm.Comanda)
            .HasForeignKey(cm => cm.ComandaId);
        }
    }
}

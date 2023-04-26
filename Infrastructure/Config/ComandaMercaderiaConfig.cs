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
            entityBuilder.HasKey(e => new { e.ComandaMercaderiaId });

            entityBuilder.Property(m => m.ComandaMercaderiaId).ValueGeneratedOnAdd();
        }
    }
}

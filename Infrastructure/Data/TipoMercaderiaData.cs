using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class TipoMercaderiaData : IEntityTypeConfiguration<TipoMercaderia>
    {
        public void Configure(EntityTypeBuilder<TipoMercaderia> entityBuilder)
        {
            entityBuilder.HasData
            (
                new TipoMercaderia
                {
                    TipoMercaderiaId = 1,
                    Descripcion = "Entrada",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 2,
                    Descripcion = "Minutas",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 3,
                    Descripcion = "Pastas",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 4,
                    Descripcion = "Parrilla",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 5,
                    Descripcion = "Pizzas",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 6,
                    Descripcion = "Sandwich",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 7,
                    Descripcion = "Ensaladas",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 8,
                    Descripcion = "Bebidas",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 9,
                    Descripcion = "Cerveza Artesanal",
                },

                new TipoMercaderia
                {
                    TipoMercaderiaId = 10,
                    Descripcion = "Postres",
                }
            );
        }
    }
}

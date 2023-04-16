using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaCommand
    {
        Mercaderia InsertMercaderia(Mercaderia mercaderia);
        Mercaderia RemoveMercaderia(int mercaderiaId);
        Mercaderia UpdateMercaderia(int mercaderiaId);
    }
}

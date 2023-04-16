using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaQuery
    {
        List<Mercaderia> GetMercaderiaList();
        Mercaderia GetMercaderiaById(int mercaderiaId);
    }
}

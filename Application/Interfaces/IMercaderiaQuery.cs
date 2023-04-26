using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaQuery
    {
        Mercaderia GetMercaderiaById(int mercaderiaId);
        List<Mercaderia> GetMercaderiaList();
        List<Mercaderia> GetMercaderiaListFilters(int tipo, string nombre, string orden);
    }
}

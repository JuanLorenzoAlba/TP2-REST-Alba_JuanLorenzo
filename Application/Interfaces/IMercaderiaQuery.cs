using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaQuery
    {
        Mercaderia GetMercaderiaById(int mercaderiaId);
        List<Mercaderia> GetMercaderiaListOrdered(int tipo, string nombre, string orden);
        List<Mercaderia> GetMercaderiaList();
        Mercaderia GetMercaderiaByFormaEntrega(int tipo);
    }
}

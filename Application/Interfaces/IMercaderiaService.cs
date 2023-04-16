using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMercaderiaService
    {
        Mercaderia CreateMercaderia(string nombre, int precio, string ingredientes, string preparacion, string imagen, TipoMercaderia tipoMercaderia);
        Mercaderia RemoveMercaderia(int mercaderiaId);
        Mercaderia UpdateMercaderia(int mercaderiaId);
        List<Mercaderia> GetMercaderiaList();
        Mercaderia GetMercaderiaById(int mercaderiaId);
    }
}

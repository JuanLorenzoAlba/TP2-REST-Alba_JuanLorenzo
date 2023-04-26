using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaMercaderiaService
    {
        ComandaMercaderia GetComandaMercaderiaById(int comandaMercaderiaId);
        List<ComandaMercaderia> GetComandaMercaderiaList();
        ComandaMercaderia CreateComandaMercaderia(Comanda comanda, Mercaderia mercaderia);
        ComandaMercaderia RemoveComandaMercaderia(int comandaMercaderiaId);
        ComandaMercaderia UpdateComandaMercaderia(int comandaMercaderiaId);
    }
}

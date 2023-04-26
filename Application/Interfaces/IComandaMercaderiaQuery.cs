using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaMercaderiaQuery
    {
        ComandaMercaderia GetComandaMercaderiaById(int comandaMercaderiaId);
        List<ComandaMercaderia> GetComandaMercaderiaList();
    }
}

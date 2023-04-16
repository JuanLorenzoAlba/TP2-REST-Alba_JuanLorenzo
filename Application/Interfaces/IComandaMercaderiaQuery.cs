using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaMercaderiaQuery
    {
        List<ComandaMercaderia> GetComandaMercaderiaList();
        ComandaMercaderia GetComandaMercaderiaById(int comandaMercaderiaId);
    }
}

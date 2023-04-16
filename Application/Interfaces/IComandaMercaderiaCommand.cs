using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaMercaderiaCommand
    {
        ComandaMercaderia InsertComandaMercaderia(ComandaMercaderia comandaMercaderia);
        ComandaMercaderia RemoveComandaMercaderia(int comandaMercaderiaId);
        ComandaMercaderia UpdateComandaMercaderia(int comandaMercaderiaId);
    }
}

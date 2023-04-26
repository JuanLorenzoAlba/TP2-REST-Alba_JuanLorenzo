using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFormaEntregaQuery
    {
        FormaEntrega GetFormaEntregaById(int formaEntregaId);
        List<FormaEntrega> GetFormaEntregaList();
    }
}

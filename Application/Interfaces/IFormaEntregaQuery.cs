using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFormaEntregaQuery
    {
        List<FormaEntrega> GetFormaEntregaList();
        FormaEntrega GetFormaEntregaById(int formaEntregaId);
    }
}

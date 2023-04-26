using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFormaEntregaService
    {
        FormaEntrega GetFormaEntregaById(int formaEntregaId);
        List<FormaEntrega> GetFormaEntregaList();
        FormaEntrega CreateFormaEntrega(string descripcion);
        FormaEntrega RemoveFormaEntrega(int formaEntregaId);
        FormaEntrega UpdateFormaEntrega(int formaEntregaId);
    }
}

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFormaEntregaService
    {
        FormaEntrega CreateFormaEntrega(string descripcion);
        FormaEntrega RemoveFormaEntrega(int formaEntregaId);
        FormaEntrega UpdateFormaEntrega(int formaEntregaId);
        List<FormaEntrega> GetFormaEntregaList();
        FormaEntrega GetFormaEntregaById(int formaEntregaId);
    }
}

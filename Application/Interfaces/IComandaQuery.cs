using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        Comanda GetComandaById(Guid comandaId);
        Comanda GetComandaByFecha(string fecha);
        List<Comanda> GetComandaList();
        List<Mercaderia> GetMercaderias(Guid comandaId);
    }
}

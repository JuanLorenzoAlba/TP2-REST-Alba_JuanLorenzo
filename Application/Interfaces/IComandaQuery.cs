using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        Comanda GetComandaById(Guid comandaId);
        List<Comanda> GetComandaListByFecha(string fecha);
        List<Comanda> GetComandaList();
        List<Mercaderia> GetMercaderias(Guid comandaId);
        void ValidadorComanda(ComandaRequest request);
    }
}

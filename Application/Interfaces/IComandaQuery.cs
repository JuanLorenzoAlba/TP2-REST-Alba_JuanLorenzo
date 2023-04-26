using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        Comanda GetComandaById(Guid comandaId);
        List<Comanda> GetComandaList();
        Comanda GetComandaByFecha(string fecha);
        Comanda GetComandaByFormaEntrega(int tipo);

        List<Mercaderia> GetMercaderias(Guid comandaId);
    }
}

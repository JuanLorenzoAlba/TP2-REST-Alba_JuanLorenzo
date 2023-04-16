using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaQuery
    {
        List<Comanda> GetComandaList();
        Comanda GetComandaById(Guid comandaId);
    }
}

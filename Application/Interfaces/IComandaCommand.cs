using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaCommand
    {
        Comanda InsertComanda(Comanda comanda);
        Comanda RemoveComanda(Guid comandaId);
        Comanda UpdateComanda(Guid comandaId);
    }
}

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaService
    {
        Comanda CreateComanda(int precioTotal, DateTime fecha, FormaEntrega formaEntrega);
        Comanda RemoveComanda(Guid comandaId);
        Comanda UpdateComanda(Guid comandaId);
        List<Comanda> GetComandaList();
        Comanda GetComandaById(Guid comandaId);

    }
}

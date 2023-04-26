using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaService
    {
        ComandaGetResponse GetComandaById(Guid comandaId);
        List<Comanda> GetComandaList();
        ComandaResponse GetComandaByFecha(string fecha);
        ComandaResponse CreateComanda(ComandaRequest request);
        Comanda RemoveComanda(Guid comandaId);
        Comanda UpdateComanda(Guid comandaId);
    }
}

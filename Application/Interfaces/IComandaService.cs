using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComandaService
    {
        ComandaGetResponse GetComandaById(Guid comandaId);
        List<ComandaResponse> GetComandaByFecha(string fecha);
        List<Comanda> GetComandaList();
        List<Mercaderia> GetMercaderias(Guid comandaId);
        ComandaResponse CreateComanda(ComandaRequest request);
        Comanda RemoveComanda(Guid comandaId);
        Comanda UpdateComanda(Guid comandaId);
        void ValidadorComanda(ComandaRequest request);
    }
}

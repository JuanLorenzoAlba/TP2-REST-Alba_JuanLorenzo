using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITipoMercaderiaQuery
    {
        TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId);
        List<TipoMercaderia> GetTipoMercaderiaList();
    }
}

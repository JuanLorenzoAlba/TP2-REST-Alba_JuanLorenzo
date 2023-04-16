using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITipoMercaderiaQuery
    {
        List<TipoMercaderia> GetTipoMercaderiaList();
        TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId);
    }
}

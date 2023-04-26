using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITipoMercaderiaService
    {
        TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId);
        List<TipoMercaderia> GetTipoMercaderiaList();
        TipoMercaderia CreateTipoMercaderia(string descripcion);
        TipoMercaderia RemoveTipoMercaderia(int tipoMercaderiaId);
        TipoMercaderia UpdateTipoMercaderia(int tipoMercaderiaId);
    }
}

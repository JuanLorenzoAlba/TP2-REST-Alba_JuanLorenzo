using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITipoMercaderiaSevice
    {
        TipoMercaderia CreateTipoMercaderia(string descripcion);
        TipoMercaderia RemoveTipoMercaderia(int tipoMercaderiaId);
        TipoMercaderia UpdateTipoMercaderia(int tipoMercaderiaId);
        List<TipoMercaderia> GetTipoMercaderiaList();
        TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId);
    }
}

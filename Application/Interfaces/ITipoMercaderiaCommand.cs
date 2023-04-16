using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITipoMercaderiaCommand
    {
        TipoMercaderia InsertTipoMercaderia(TipoMercaderia tipoMercaderia);
        TipoMercaderia RemoveTipoMercaderia(int tipoMercaderiaId);
        TipoMercaderia UpdateTipoMercaderia(int tipoMercaderiaId);
    }
}

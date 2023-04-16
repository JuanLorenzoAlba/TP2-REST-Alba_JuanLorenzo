using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase.TipoMercaderias
{
    public class TipoMercaderiaService : ITipoMercaderiaSevice
    {
        private readonly ITipoMercaderiaCommand _command;
        private readonly ITipoMercaderiaQuery _query;

        public TipoMercaderiaService(ITipoMercaderiaCommand command, ITipoMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId)
        {
            return _query.GetTipoMercaderiaById(tipoMercaderiaId);
        }

        public List<TipoMercaderia> GetTipoMercaderiaList()
        {
            return _query.GetTipoMercaderiaList();
        }

        public TipoMercaderia CreateTipoMercaderia(string descripcion)
        {
            var tipoMercaderia = new TipoMercaderia
            {
                Descripcion = descripcion
            };

            return _command.InsertTipoMercaderia(tipoMercaderia);
        }

        public TipoMercaderia RemoveTipoMercaderia(int tipoMercaderiaId)
        {
            return _command.RemoveTipoMercaderia(tipoMercaderiaId);
        }

        public TipoMercaderia UpdateTipoMercaderia(int tipoMercaderiaId)
        {
            return _command.UpdateTipoMercaderia(tipoMercaderiaId);
        }
    }
}

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Querys
{
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly RestaurantContext _context;

        public TipoMercaderiaQuery(RestaurantContext context)
        {
            _context = context;
        }

        public TipoMercaderia GetTipoMercaderiaById(int tipoMercaderiaId)
        {
            var getGetTipoMercaderiaById = _context.TipoMercaderias.Single(x => x.TipoMercaderiaId == tipoMercaderiaId);
            return getGetTipoMercaderiaById;
        }

        public List<TipoMercaderia> GetTipoMercaderiaList()
        {
            var getTipoMercaderiaList = _context.TipoMercaderias.ToList();
            return getTipoMercaderiaList;
        }
    }
}

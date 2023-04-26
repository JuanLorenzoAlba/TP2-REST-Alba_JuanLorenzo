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
            var getTipoMercaderiaById = _context.TipoMercaderias.Single(x => x.TipoMercaderiaId == tipoMercaderiaId);
            return getTipoMercaderiaById;
        }

        public List<TipoMercaderia> GetTipoMercaderiaList()
        {
            var getTipoMercaderiaList = _context.TipoMercaderias.ToList();
            return getTipoMercaderiaList;
        }
    }
}

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
            var tipoMercaderia = _context.TipoMercaderias.FirstOrDefault(x => x.TipoMercaderiaId == tipoMercaderiaId);

            return tipoMercaderia;
        }

        public List<TipoMercaderia> GetTipoMercaderiaList()
        {
            var tipoMercaderiaList = _context.TipoMercaderias.ToList();

            return tipoMercaderiaList;
        }
    }
}

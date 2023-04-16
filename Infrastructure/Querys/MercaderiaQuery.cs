using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Querys
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly RestaurantContext _context;

        public MercaderiaQuery(RestaurantContext context)
        {
            _context = context;
        }

        public Mercaderia GetMercaderiaById(int mercaderiaId)
        {
            var getGetMercaderiaById = _context.Mercaderias.Single(x => x.MercaderiaId == mercaderiaId);
            return getGetMercaderiaById;
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            var getMercaderiaList = _context.Mercaderias.ToList();
            return getMercaderiaList;
        }
    }
}

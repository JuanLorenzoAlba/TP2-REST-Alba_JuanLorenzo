using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Querys
{
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private readonly RestaurantContext _context;

        public ComandaMercaderiaQuery(RestaurantContext context)
        {
            _context = context;
        }

        public ComandaMercaderia GetComandaMercaderiaById(int comandaMercaderiaId)
        {
            var getGetComandaMercaderiaById = _context.ComandasMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderiaId);
            return getGetComandaMercaderiaById;
        }

        public List<ComandaMercaderia> GetComandaMercaderiaList()
        {
            var getComandaMercaderiaList = _context.ComandasMercaderias.ToList();
            return getComandaMercaderiaList;
        }
    }
}

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
            var comandaMercaderia = _context.ComandasMercaderias.FirstOrDefault(x => x.ComandaMercaderiaId == comandaMercaderiaId);

            return comandaMercaderia;
        }

        public List<ComandaMercaderia> GetComandaMercaderiaList()
        {
            var comandaMercaderiaList = _context.ComandasMercaderias.ToList();

            return comandaMercaderiaList;
        }
    }
}

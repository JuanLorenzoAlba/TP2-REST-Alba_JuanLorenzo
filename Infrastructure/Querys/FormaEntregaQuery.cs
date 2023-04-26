using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Querys
{
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly RestaurantContext _context;

        public FormaEntregaQuery(RestaurantContext context)
        {
            _context = context;
        }

        public FormaEntrega GetFormaEntregaById(int formaEntregaId)
        {
            var getFormaEntregaById = _context.FormaEntregas.FirstOrDefault(x => x.FormaEntregaId == formaEntregaId);
            return getFormaEntregaById;
        }

        public List<FormaEntrega> GetFormaEntregaList()
        {
            var getFormaEntregaList = _context.FormaEntregas.ToList();
            return getFormaEntregaList;
        }
    }
}

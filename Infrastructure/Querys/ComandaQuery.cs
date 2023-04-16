using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Querys
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly RestaurantContext _context;

        public ComandaQuery(RestaurantContext context)
        {
            _context = context;
        }

        public Comanda GetComandaById(Guid comandaId)
        {
            var getGetComandaById = _context.Comandas.Single(x => x.ComandaId == comandaId);
            return getGetComandaById;
        }

        public List<Comanda> GetComandaList()
        {
            var getComandaList = _context.Comandas.ToList();
            return getComandaList;
        }
    }
}

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            var comanda = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.ComandaId == comandaId);

            return comanda;
        }

        public Comanda GetComandaByFecha(string fecha)
        {
            DateTime dateTime = DateTime.Parse(fecha);

            var comanda = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.Fecha == dateTime);

            return comanda;
        }

        public List<Comanda> GetComandaList()
        {
            var comandaList = _context.Comandas.ToList();

            return comandaList;
        }

        public List<Mercaderia> GetMercaderias(Guid comandaId)
        {
            var comandaList = _context.Comandas
                .Include(cm => cm.ComandasMercaderias)
                .ThenInclude(m => m.Mercaderia)
                .ThenInclude(m => m.TipoMercaderia)
                .FirstOrDefault(c => c.ComandaId == comandaId);


            var mercaderiaList = comandaList.ComandasMercaderias
                .Select(cm => cm.Mercaderia)
                .ToList();

            return mercaderiaList;
        }
    }
}

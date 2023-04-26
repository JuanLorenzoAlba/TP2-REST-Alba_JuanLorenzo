using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            var getComandaById = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.ComandaId == comandaId);

            return getComandaById;
        }

        public List<Comanda> GetComandaList()
        {
            var getComandaList = _context.Comandas.ToList();
            return getComandaList;
        }

        public Comanda GetComandaByFecha(string fecha)
        {
            DateTime dateTime = DateTime.Parse(fecha);

            var getComandaByFecha = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.Fecha == dateTime);

            return getComandaByFecha;
        }

        public Comanda GetComandaByFormaEntrega(int tipo)
        {
            var getComandaById = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.FormaEntrega.FormaEntregaId == tipo);

            return getComandaById;
        }


        public List<Mercaderia> GetMercaderias(Guid comandaId)
        {
            var comanda = _context.Comandas
                .Include(cm => cm.ComandasMercaderias)
                .ThenInclude(m => m.Mercaderia)
                .FirstOrDefault(c => c.ComandaId == comandaId);


            var mercaderias = comanda.ComandasMercaderias
                .Select(cm => cm.Mercaderia)
                .ToList();

            return mercaderias;
        }
    }
}

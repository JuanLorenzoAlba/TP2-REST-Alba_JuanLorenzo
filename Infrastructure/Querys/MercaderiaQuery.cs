using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            var mercaderia = _context.Mercaderias
                .Include(s => s.TipoMercaderia)
                .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

            return mercaderia;
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            var mercaderiaList = _context.Mercaderias.ToList();

            return mercaderiaList;
        }

        public List<Mercaderia> GetMercaderiaListFilters(int tipo, string nombre, string orden)
        {
            var mercaderiaList = _context.Mercaderias
                .Include(s => s.TipoMercaderia)
                .OrderBy(p => p.Precio)
                .ToList();

            if (tipo != 0)
            {
                mercaderiaList = mercaderiaList.Where(p => p.TipoMercaderiaId == tipo).ToList();
            }

            if (nombre != null)
            {
                mercaderiaList = mercaderiaList.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }

            if (orden.ToLower() == "desc")
            {
                mercaderiaList = mercaderiaList.OrderByDescending(p => p.Precio).ToList();
            }

            return mercaderiaList;
        }

        public bool ExisteMercaderiaEnComanda(int mercaderiaId)
        {
            bool existeMercaderia = _context.Comandas
                .Any(c => c.ComandasMercaderias
                .Any(cm => cm.MercaderiaId == mercaderiaId));

            if (existeMercaderia)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExisteMercaderiaNombre(string nombre)
        {
            bool existeMercaderia = _context.Mercaderias
                .Include(s => s.TipoMercaderia)
                .Any(x => x.Nombre.ToLower() == nombre.ToLower());

            if (existeMercaderia)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

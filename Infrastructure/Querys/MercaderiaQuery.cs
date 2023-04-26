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
            var getMercaderiaById = _context.Mercaderias
                .Include(s => s.TipoMercaderia)
                .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

            return getMercaderiaById;
        }

        public Mercaderia GetMercaderiaByFormaEntrega(int tipo)
        {
            var getMercaderiaById = _context.Mercaderias
                .Include(s => s.TipoMercaderia)
                .FirstOrDefault(x => x.TipoMercaderia.TipoMercaderiaId == tipo);

            return getMercaderiaById;
        }

        public List<Mercaderia> GetMercaderiaListOrdered(int tipo, string nombre, string orden)
        {
            var GetMercaderiaByParametros = _context.Mercaderias
                   .Include(s => s.TipoMercaderia)
                   .OrderBy(p => p.Precio)
                   .ToList();

            if (tipo != 0)
            {
                GetMercaderiaByParametros = GetMercaderiaByParametros.Where(p => p.TipoMercaderiaId == tipo).ToList(); ;
            }

            if(nombre != null)
            {
                GetMercaderiaByParametros = GetMercaderiaByParametros.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }

            if (orden.ToLower() == "desc")
            {
                GetMercaderiaByParametros = GetMercaderiaByParametros.OrderByDescending(p => p.Precio).ToList();
            }
            
            return GetMercaderiaByParametros;
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            var getMercaderiaList = _context.Mercaderias.ToList();
            return getMercaderiaList;
        }
    }
}

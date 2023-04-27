using Application.Interfaces;
using Application.Request;
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

        public List<Comanda> GetComandaListByFecha(string fecha)
        {
            var comandaList = _context.Comandas
                .Include(s => s.FormaEntrega)
                .ToList();

            if (fecha != null)
            {
                DateTime dateTime = DateTime.Parse(fecha);
                comandaList = comandaList.Where(p => p.Fecha == dateTime).ToList();
            }

            return comandaList;
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

        public void ValidadorComanda(ComandaRequest request)
        {
            foreach (var mercaderiaId in request.Mercaderias)
            {
                var mercaderia = _context.Mercaderias.FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

                if (mercaderia == null)
                {
                    throw new ArgumentException($"No se encontró la mercadería con el identificador '{mercaderiaId}'.");
                }
            }

            var formaEntrega = _context.FormaEntregas.FirstOrDefault(x => x.FormaEntregaId == request.FormaEntrega);

            if (formaEntrega == null)
            {
                throw new ArgumentException($"No se encontró la forma de entrega con el identificador '{request.FormaEntrega}'.");
            }
        }
    }
}

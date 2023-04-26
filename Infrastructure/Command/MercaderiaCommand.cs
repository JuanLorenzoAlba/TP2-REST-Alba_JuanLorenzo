using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class MercaderiaCommand : IMercaderiaCommand
    {
        private readonly RestaurantContext _context;

        public MercaderiaCommand(RestaurantContext context)
        {
            _context = context;
        }

        public Mercaderia InsertMercaderia(Mercaderia mercaderia)
        {
            _context.Add(mercaderia);
            _context.SaveChanges();

            return mercaderia;
        }

        public Mercaderia RemoveMercaderia(int mercaderiaId)
        {
            var mercaderia = _context.Mercaderias
            .Include(s => s.TipoMercaderia)
            .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

            _context.Remove(mercaderia);
            _context.SaveChanges();

            return mercaderia;
        }

        public Mercaderia UpdateMercaderia(Mercaderia mercaderia)
        {
            _context.Update(mercaderia);
            _context.SaveChanges();

            return mercaderia;
        }
    }
}

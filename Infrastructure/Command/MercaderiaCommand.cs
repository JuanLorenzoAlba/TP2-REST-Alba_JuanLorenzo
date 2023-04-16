using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

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
            var removeMercaderiaId = _context.Mercaderias.Single(x => x.MercaderiaId == mercaderiaId);
            _context.Remove(removeMercaderiaId);
            _context.SaveChanges();

            return removeMercaderiaId;
        }

        public Mercaderia UpdateMercaderia(int mercaderiaId)
        {
            var updateMercaderiaId = _context.Mercaderias.Single(x => x.MercaderiaId == mercaderiaId);
            _context.Update(updateMercaderiaId);
            _context.SaveChanges();

            return updateMercaderiaId;
        }
    }
}

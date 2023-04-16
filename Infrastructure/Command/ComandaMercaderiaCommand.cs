using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class ComandaMercaderiaCommand : IComandaMercaderiaCommand
    {
        private readonly RestaurantContext _context;

        public ComandaMercaderiaCommand(RestaurantContext context)
        {
            _context = context;
        }

        public ComandaMercaderia InsertComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            _context.Add(comandaMercaderia);
            _context.SaveChanges();

            return comandaMercaderia;
        }

        public ComandaMercaderia RemoveComandaMercaderia(int comandaMercaderiaId)
        {
            var removeComandaMercaderiaId = _context.ComandasMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderiaId);
            _context.Remove(removeComandaMercaderiaId);
            _context.SaveChanges();

            return removeComandaMercaderiaId;
        }

        public ComandaMercaderia UpdateComandaMercaderia(int comandaMercaderiaId)
        {
            var updateComandaMercaderiaId = _context.ComandasMercaderias.Single(x => x.ComandaMercaderiaId == comandaMercaderiaId);
            _context.Update(updateComandaMercaderiaId);
            _context.SaveChanges();

            return updateComandaMercaderiaId;
        }
    }
}

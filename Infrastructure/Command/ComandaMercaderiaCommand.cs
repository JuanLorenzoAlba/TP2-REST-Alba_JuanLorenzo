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
            var comandaMercaderia = _context.ComandasMercaderias.FirstOrDefault(x => x.ComandaMercaderiaId == comandaMercaderiaId);
            _context.Remove(comandaMercaderia);
            _context.SaveChanges();

            return comandaMercaderia;
        }

        public ComandaMercaderia UpdateComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            _context.Update(comandaMercaderia);
            _context.SaveChanges();

            return comandaMercaderia;
        }
    }
}

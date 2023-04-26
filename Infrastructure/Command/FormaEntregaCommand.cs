using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class FormaEntregaCommand : IFormaEntregaCommand
    {
        private readonly RestaurantContext _context;

        public FormaEntregaCommand(RestaurantContext context)
        {
            _context = context;
        }

        public FormaEntrega InsertFormaEntrega(FormaEntrega formaEntrega)
        {
            _context.Add(formaEntrega);
            _context.SaveChanges();

            return formaEntrega;
        }

        public FormaEntrega RemoveFormaEntrega(int formaEntregaId)
        {
            var formaEntrega = _context.FormaEntregas.FirstOrDefault(x => x.FormaEntregaId == formaEntregaId);
            _context.Remove(formaEntrega);
            _context.SaveChanges();

            return formaEntrega;
        }

        public FormaEntrega UpdateFormaEntrega(FormaEntrega formaEntrega)
        {
            _context.Update(formaEntrega);
            _context.SaveChanges();

            return formaEntrega;
        }
    }
}

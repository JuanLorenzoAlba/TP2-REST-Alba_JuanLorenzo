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
            var removeFormaEntregaId = _context.FormaEntregas.Single(x => x.FormaEntregaId == formaEntregaId);
            _context.Remove(removeFormaEntregaId);
            _context.SaveChanges();

            return removeFormaEntregaId;
        }

        public FormaEntrega UpdateFormaEntrega(int formaEntregaId)
        {
            var updateFormaEntregaId = _context.FormaEntregas.Single(x => x.FormaEntregaId == formaEntregaId);
            _context.Update(updateFormaEntregaId);
            _context.SaveChanges();

            return updateFormaEntregaId;
        }
    }
}

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class ComandaCommand : IComandaCommand
    {
        private readonly RestaurantContext _context;

        public ComandaCommand(RestaurantContext context)
        {
            _context = context;
        }

        public Comanda InsertComanda(Comanda comanda)
        {
            _context.Add(comanda);
            _context.SaveChanges();

            return comanda;
        }

        public Comanda RemoveComanda(Guid comandaId)
        {
            var removeComandaId = _context.Comandas.Single(x => x.ComandaId == comandaId);
            _context.Remove(removeComandaId);
            _context.SaveChanges();

            return removeComandaId;
        }

        public Comanda UpdateComanda(Guid comandaId)
        {
            var updateComandaId = _context.Comandas.Single(x => x.ComandaId == comandaId);
            _context.Update(updateComandaId);
            _context.SaveChanges();

            return updateComandaId;
        }
    }
}

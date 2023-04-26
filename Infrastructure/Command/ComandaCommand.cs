using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            var comanda = _context.Comandas
                .Include(s => s.FormaEntrega)
                .FirstOrDefault(x => x.ComandaId == comandaId);

            _context.Remove(comanda);
            _context.SaveChanges();

            return comanda;
        }

        public Comanda UpdateComanda(Comanda comanda)
        {
            _context.Update(comanda);
            _context.SaveChanges();

            return comanda;
        }
    }
}

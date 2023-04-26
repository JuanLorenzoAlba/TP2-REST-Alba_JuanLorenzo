using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        private readonly RestaurantContext _context;

        public TipoMercaderiaCommand(RestaurantContext context)
        {
            _context = context;
        }

        public TipoMercaderia InsertTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            _context.Add(tipoMercaderia);
            _context.SaveChanges();

            return tipoMercaderia;
        }

        public TipoMercaderia RemoveTipoMercaderia(int tipoMercaderiaId)
        {
            var tipoMercaderia = _context.TipoMercaderias.FirstOrDefault(x => x.TipoMercaderiaId == tipoMercaderiaId);
            _context.Remove(tipoMercaderia);
            _context.SaveChanges();

            return tipoMercaderia;
        }

        public TipoMercaderia UpdateTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            _context.Update(tipoMercaderia);
            _context.SaveChanges();

            return tipoMercaderia;
        }
    }
}

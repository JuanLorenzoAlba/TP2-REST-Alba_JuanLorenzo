using Application.Interfaces;
using Application.Request;
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
            var removeMercaderiaId = _context.Mercaderias
            .Include(s => s.TipoMercaderia)
            .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

            _context.Remove(removeMercaderiaId);
            _context.SaveChanges();


            return removeMercaderiaId;
        }

        public Mercaderia UpdateMercaderia(int mercaderiaId, MercaderiaRequest request)
        {
            var updateMercaderia = _context.Mercaderias
            .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);

            var tipoMercaderia = _context.TipoMercaderias
            .FirstOrDefault(x => x.TipoMercaderiaId == request.tipo);

            updateMercaderia.Nombre = request.nombre;
            updateMercaderia.Precio = request.precio;
            updateMercaderia.Ingredientes = request.ingredientes;
            updateMercaderia.Preparacion = request.preparacion;
            updateMercaderia.Imagen = request.imagen;
            updateMercaderia.TipoMercaderia = tipoMercaderia;
            updateMercaderia.TipoMercaderiaId = tipoMercaderia.TipoMercaderiaId;

            _context.Update(updateMercaderia);
            _context.SaveChanges();


            return updateMercaderia;
        }
    }
}

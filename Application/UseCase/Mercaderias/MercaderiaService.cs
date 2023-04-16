using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase.Mercaderias
{
    public class MercaderiaService : IMercaderiaService
    {

        private readonly IMercaderiaCommand _command;
        private readonly IMercaderiaQuery _query;

        public MercaderiaService(IMercaderiaCommand command, IMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public Mercaderia GetMercaderiaById(int mercaderiaId)
        {
            return _query.GetMercaderiaById(mercaderiaId);
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            return _query.GetMercaderiaList();
        }

        public Mercaderia CreateMercaderia(string nombre, int precio, string ingredientes, string preparacion, string imagen, TipoMercaderia tipoMercaderia)
        {
            var mercaderia = new Mercaderia
            {
                Nombre = nombre,
                Precio = precio,
                Ingredientes = ingredientes,
                Preparacion = preparacion,
                Imagen = imagen,
                TipoMercaderia = tipoMercaderia,
                TipoMercaderiaId = tipoMercaderia.TipoMercaderiaId
            };

            return _command.InsertMercaderia(mercaderia);
        }

        public Mercaderia RemoveMercaderia(int mercaderiaId)
        {
            return _command.RemoveMercaderia(mercaderiaId);
        }

        public Mercaderia UpdateMercaderia(int mercaderiaId)
        {
            return _command.UpdateMercaderia(mercaderiaId);
        }
    }
}

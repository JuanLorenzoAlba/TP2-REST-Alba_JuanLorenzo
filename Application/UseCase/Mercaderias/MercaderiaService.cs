using Application.Interfaces;
using Application.Request;
using Application.Response;
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

        public MercaderiaResponse GetMercaderiaById(int mercaderiaId)
        {
            var mercaderia = _query.GetMercaderiaById(mercaderiaId);

            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderiaId,
                    descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen,
            };
        }

        public List<MercaderiaGetResponse> GetMercaderiaListOrdered(int tipo, string nombre, string orden)
        {
            var mercaderiaList = _query.GetMercaderiaListOrdered(tipo, nombre, orden);

            var mercaderiaListResponse = new List<MercaderiaGetResponse>();

            foreach (var x in mercaderiaList)
            {
                var mercaderiaResponse = new MercaderiaGetResponse
                {
                    id = x.MercaderiaId,
                    nombre = x.Nombre,
                    imagen = x.Imagen,
                    precio = x.Precio,
                    tipo = new TipoMercaderiaResponse
                    {
                        id = x.TipoMercaderia.TipoMercaderiaId,
                        descripcion = x.TipoMercaderia.Descripcion
                    }
                };
                mercaderiaListResponse.Add(mercaderiaResponse);
            }

            return mercaderiaListResponse;
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            return _query.GetMercaderiaList();
        }

        public MercaderiaResponse CreateMercaderia(MercaderiaRequest request)
        {
            var mercaderia = new Mercaderia
            {
                Nombre = request.nombre,
                Precio = request.precio,
                Ingredientes = request.ingredientes,
                Preparacion = request.preparacion,
                Imagen = request.imagen,
                TipoMercaderiaId = request.tipo,
                TipoMercaderia = _query.GetMercaderiaByFormaEntrega(request.tipo).TipoMercaderia
            };

            _command.InsertMercaderia(mercaderia);

            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderiaId,
                    descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen,
            };
        }

        public MercaderiaResponse RemoveMercaderia(int mercaderiaId)
        {
            var mercaderia = _command.RemoveMercaderia(mercaderiaId);

            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderiaId,
                    descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen,
            };
        }

        public MercaderiaResponse UpdateMercaderia(int mercaderiaId, MercaderiaRequest request)
        {
            var mercaderia = _command.UpdateMercaderia(mercaderiaId, request);

            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderiaId,
                    descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen,
            };
        }
    }
}

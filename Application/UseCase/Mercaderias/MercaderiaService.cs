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

        private readonly ITipoMercaderiaQuery _tipoMercaderiaQuery;

        public MercaderiaService(IMercaderiaCommand command, IMercaderiaQuery query, ITipoMercaderiaQuery tipoMercaderiaQuery)
        {
            _command = command;
            _query = query;
            _tipoMercaderiaQuery = tipoMercaderiaQuery;
        }

        public MercaderiaResponse GetMercaderiaById(int mercaderiaId)
        {
            var mercaderia = _query.GetMercaderiaById(mercaderiaId);

            return new MercaderiaResponse
            {
                Id = mercaderia.MercaderiaId,
                Nombre = mercaderia.Nombre,
                Tipo = new TipoMercaderiaResponse
                {
                    Id = mercaderia.TipoMercaderiaId,
                    Descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen,
            };
        }

        public List<Mercaderia> GetMercaderiaList()
        {
            return _query.GetMercaderiaList();
        }

        public List<MercaderiaGetResponse> GetMercaderiaListFilters(int tipo, string nombre, string orden)
        {
            var mercaderiaList = _query.GetMercaderiaListFilters(tipo, nombre, orden);

            List<MercaderiaGetResponse> MercaderiaGetResponseList = new List<MercaderiaGetResponse>();

            foreach (var mercaderia in mercaderiaList)
            {
                var mercaderiaResponse = new MercaderiaGetResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,
                    Imagen = mercaderia.Imagen,
                    Precio = mercaderia.Precio,
                    Tipo = new TipoMercaderiaResponse
                    {
                        Id = mercaderia.TipoMercaderia.TipoMercaderiaId,
                        Descripcion = mercaderia.TipoMercaderia.Descripcion
                    }
                };
                MercaderiaGetResponseList.Add(mercaderiaResponse);
            }

            return MercaderiaGetResponseList;
        }

        public MercaderiaResponse CreateMercaderia(MercaderiaRequest request)
        {
            var mercaderia = new Mercaderia
            {
                Nombre = request.Nombre,
                Precio = request.Precio,
                Ingredientes = request.Ingredientes,
                Preparacion = request.Preparacion,
                Imagen = request.Imagen,
                TipoMercaderiaId = request.Tipo,
                TipoMercaderia = _tipoMercaderiaQuery.GetTipoMercaderiaById(request.Tipo)
        };

            _command.InsertMercaderia(mercaderia);

            return new MercaderiaResponse
            {
                Id = mercaderia.MercaderiaId,
                Nombre = mercaderia.Nombre,
                Tipo = new TipoMercaderiaResponse
                {
                    Id = mercaderia.TipoMercaderiaId,
                    Descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen,
            };
        }

        public MercaderiaResponse RemoveMercaderia(int mercaderiaId)
        {
            var mercaderia = _command.RemoveMercaderia(mercaderiaId);

            return new MercaderiaResponse
            {
                Id = mercaderia.MercaderiaId,
                Nombre = mercaderia.Nombre,
                Tipo = new TipoMercaderiaResponse
                {
                    Id = mercaderia.TipoMercaderiaId,
                    Descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen,
            };
        }

        public MercaderiaResponse UpdateMercaderia(int mercaderiaId, MercaderiaRequest request)
        {
            var mercaderia = _query.GetMercaderiaById(mercaderiaId);

            mercaderia.Nombre = request.Nombre;
            mercaderia.Precio = request.Precio;
            mercaderia.Ingredientes = request.Ingredientes;
            mercaderia.Preparacion = request.Preparacion;
            mercaderia.Imagen = request.Imagen;
            mercaderia.TipoMercaderiaId = request.Tipo;
            mercaderia.TipoMercaderia = _tipoMercaderiaQuery.GetTipoMercaderiaById(request.Tipo);

            _command.UpdateMercaderia(mercaderia);

            return new MercaderiaResponse
            {
                Id = mercaderia.MercaderiaId,
                Nombre = mercaderia.Nombre,
                Tipo = new TipoMercaderiaResponse
                {
                    Id = mercaderia.TipoMercaderiaId,
                    Descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen,
            };
        }
    }
}

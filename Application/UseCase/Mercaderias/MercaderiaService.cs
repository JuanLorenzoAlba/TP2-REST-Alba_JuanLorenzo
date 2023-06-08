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

        private readonly ITipoMercaderiaService _tipoMercaderiaService;

        public MercaderiaService(IMercaderiaCommand command, IMercaderiaQuery query, ITipoMercaderiaService tipoMercaderiaService)
        {
            _command = command;
            _query = query;
            _tipoMercaderiaService = tipoMercaderiaService;
        }

        public MercaderiaResponse GetMercaderiaById(int mercaderiaId)
        {
            var mercaderia = _query.GetMercaderiaById(mercaderiaId);

            if (mercaderia == null)
            {
                throw new ArgumentException($"No se encontró la mercaderia con el identificador {mercaderiaId}.");
            }

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

            List<MercaderiaGetResponse> mercaderiaGetResponseList = new List<MercaderiaGetResponse>();

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
                mercaderiaGetResponseList.Add(mercaderiaResponse);
            }

            return mercaderiaGetResponseList;
        }

        public MercaderiaResponse CreateMercaderia(MercaderiaRequest request)
        {
            if (_tipoMercaderiaService.GetTipoMercaderiaById(request.Tipo) == null)
            {
                throw new ArgumentException($"No se encontró el tipo de mercaderia con el identificador {request.Tipo}.");
            }

            var mercaderia = new Mercaderia
            {
                Nombre = request.Nombre,
                Precio = request.Precio,
                Ingredientes = request.Ingredientes,
                Preparacion = request.Preparacion,
                Imagen = request.Imagen,
                TipoMercaderiaId = request.Tipo,
                TipoMercaderia = _tipoMercaderiaService.GetTipoMercaderiaById(request.Tipo)
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
            if (_query.GetMercaderiaById(mercaderiaId) == null)
            {
                throw new ArgumentException($"No se encontró la mercaderia que desea eliminar con el identificador '{mercaderiaId}'.");
            }

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

            if (mercaderia == null)
            {
                throw new ArgumentException($"No se encontró la mercaderia con el identificador {mercaderiaId}.");
            }

            if (_tipoMercaderiaService.GetTipoMercaderiaById(request.Tipo) == null)
            {
                throw new Exception($"No se encontró el tipo de mercaderia con el identificador {request.Tipo}.");
            }

            mercaderia.Nombre = request.Nombre;
            mercaderia.Precio = request.Precio;
            mercaderia.Ingredientes = request.Ingredientes;
            mercaderia.Preparacion = request.Preparacion;
            mercaderia.Imagen = request.Imagen;
            mercaderia.TipoMercaderiaId = request.Tipo;
            mercaderia.TipoMercaderia = _tipoMercaderiaService.GetTipoMercaderiaById(request.Tipo);

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

        public bool ExisteMercaderiaEnComanda(int mercaderiaId)
        {
            return _query.ExisteMercaderiaEnComanda(mercaderiaId);
        }

        public bool ExisteMercaderiaNombre(string nombre)
        {
            return _query.ExisteMercaderiaNombre(nombre);
        }
    }
}

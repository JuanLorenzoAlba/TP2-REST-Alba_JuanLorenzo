using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.Comandas
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaCommand _command;
        private readonly IComandaQuery _query;

        private readonly IMercaderiaQuery _mercaderiaQuery;

        private readonly IComandaMercaderiaService _comandaMercaderiaService;

        private readonly IFormaEntregaQuery _formaEntregaQuery;

        public ComandaService(IComandaCommand command, IComandaQuery query, IMercaderiaQuery mercaderiaQuery, IComandaMercaderiaService comandaMercaderiaService, IFormaEntregaQuery formaEntregaQuery)
        {
            _command = command;
            _query = query;
            _mercaderiaQuery = mercaderiaQuery;
            _comandaMercaderiaService = comandaMercaderiaService;
            _formaEntregaQuery = formaEntregaQuery;
        }

        public ComandaGetResponse GetComandaById(Guid comandaId)
        {
            var comanda = _query.GetComandaById(comandaId);

            List<MercaderiaGetResponse> mercaderiaGetResponseList = new List<MercaderiaGetResponse>();

            foreach (var mercaderia in _query.GetMercaderias(comanda.ComandaId))
            {
                mercaderiaGetResponseList.Add(new MercaderiaGetResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,
                    Precio = mercaderia.Precio,
                    Tipo = new TipoMercaderiaResponse
                    {
                        Id = mercaderia.TipoMercaderia.TipoMercaderiaId,
                        Descripcion = mercaderia.TipoMercaderia.Descripcion,
                    },
                    Imagen = mercaderia.Imagen,
                });
            }

            return new ComandaGetResponse
            {
                Id = comanda.ComandaId,
                Mercaderias = mercaderiaGetResponseList,
                FormaEntrega = new FormaEntregaResponse
                {
                    Id = comanda.FormaEntregaId,
                    Descripcion = comanda.FormaEntrega.Descripcion
                },
                Total = comanda.PrecioTotal,
                Fecha = comanda.Fecha,
            };

        }

        public ComandaResponse GetComandaByFecha(string fecha)
        {
            var comanda = _query.GetComandaByFecha(fecha);

            List<MercaderiaComandaResponse> mercaderiaComandaResponseList = new List<MercaderiaComandaResponse>();

            foreach (var mercaderia in _query.GetMercaderias(comanda.ComandaId))
            {
                mercaderiaComandaResponseList.Add(new MercaderiaComandaResponse
                {
                    Id = mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,
                    Precio = mercaderia.Precio,
                });
            }

            return new ComandaResponse
            {
                Id = comanda.ComandaId,
                Mercaderias = mercaderiaComandaResponseList,
                FormaEntrega = new FormaEntregaResponse
                {
                    Id = comanda.FormaEntregaId,
                    Descripcion = comanda.FormaEntrega.Descripcion
                },

                Total = comanda.PrecioTotal,
                Fecha = comanda.Fecha,
            };
        }

        public List<Comanda> GetComandaList()
        {
            return _query.GetComandaList();
        }

        public List<Mercaderia> GetMercaderias(Guid comandaId)
        {
            return _query.GetMercaderias(comandaId);
        }

        public ComandaResponse CreateComanda(ComandaRequest request)
        {
            int precioTotal = 0;

            List<Mercaderia> mercaderiaList = request.Mercaderias.Select(_mercaderiaQuery.GetMercaderiaById).ToList();

            List<MercaderiaComandaResponse> MercaderiaComandaResponseList = mercaderiaList

                .Select(x => new MercaderiaComandaResponse
                {
                    Id = x.MercaderiaId,
                    Nombre = x.Nombre,
                    Precio = x.Precio,

                }).ToList();

            precioTotal = mercaderiaList.Sum(x => x.Precio);

            var comanda = new Comanda
            {
                PrecioTotal = precioTotal,
                Fecha = DateTime.Now.Date,
                FormaEntregaId = request.FormaEntrega,
                FormaEntrega = _formaEntregaQuery.GetFormaEntregaById(request.FormaEntrega),
            };
            _command.InsertComanda(comanda);

            foreach (var mercaderia in mercaderiaList)
            {
                _comandaMercaderiaService.CreateComandaMercaderia(comanda, mercaderia);
            }

            return new ComandaResponse
            {
                Id = comanda.ComandaId,
                Mercaderias = MercaderiaComandaResponseList,
                FormaEntrega = new FormaEntregaResponse
                {
                    Id = comanda.FormaEntregaId,
                    Descripcion = comanda.FormaEntrega.Descripcion
                },
                Total = comanda.PrecioTotal,
                Fecha = comanda.Fecha,
            };
        }

        public Comanda RemoveComanda(Guid comandaId)
        {
            return _command.RemoveComanda(comandaId);
        }

        public Comanda UpdateComanda(Guid comandaId)
        {
            var comanda = _query.GetComandaById(comandaId);

            return _command.UpdateComanda(comanda);
        }
    }
}

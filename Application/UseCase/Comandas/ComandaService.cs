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

        private readonly IFormaEntregaService _formaEntregaService;

        public ComandaService(IComandaCommand command, IComandaQuery query, IMercaderiaQuery mercaderiaQuery, IComandaMercaderiaService comandaMercaderiaService, IFormaEntregaService formaEntregaService)
        {
            _command = command;
            _query = query;
            _mercaderiaQuery = mercaderiaQuery;
            _comandaMercaderiaService = comandaMercaderiaService;
            _formaEntregaService = formaEntregaService;
        }

        public ComandaGetResponse GetComandaById(Guid comandaId)
        {
            var comanda = _query.GetComandaById(comandaId);

            if (comanda == null)
            {
                throw new ArgumentException($"No se encontró la comanda con el identificador '{comandaId}'.");
            }

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

        public List<ComandaResponse> GetComandaByFecha(string fecha)
        {
            var comandaList = _query.GetComandaListByFecha(fecha);

            List<ComandaResponse> comandaResponseList = new List<ComandaResponse>();

            foreach (var comanda in comandaList)
            {
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

                comandaResponseList.Add(new ComandaResponse
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
                });
            }
            return comandaResponseList;
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
            _query.ValidadorComanda(request);

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
                FormaEntrega = _formaEntregaService.GetFormaEntregaById(request.FormaEntrega),
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

        public void ValidadorComanda(ComandaRequest request)
        {
            _query.ValidadorComanda(request);
        }
    }
}

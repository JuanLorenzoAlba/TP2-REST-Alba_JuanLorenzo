using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.UseCase.ComandasMercaderias;
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

            List<MercaderiaGetResponse> mercaderiaGetResponses = new List<MercaderiaGetResponse>();

            var getComanda = _query.GetComandaById(comandaId);

            return new ComandaGetResponse
            {
                id = getComanda.ComandaId,
                mercaderias = mercaderiaGetResponses
            };

        }

        public List<Comanda> GetComandaList()
        {
            return _query.GetComandaList();
        }

        public ComandaResponse GetComandaByFecha(string fecha)
        {
            var comanda = _query.GetComandaByFecha(fecha);

            List<MercaderiaComandaResponse> mercaderiasResponse = new List<MercaderiaComandaResponse>();

            foreach(var x in _query.GetMercaderias(comanda.ComandaId))
            {
                mercaderiasResponse.Add(new MercaderiaComandaResponse
                {
                    id = x.MercaderiaId,
                    nombre = x.Nombre,
                    precio = x.Precio,
                });
            }

            return new ComandaResponse
            {
                id = comanda.ComandaId,
                mercaderias = mercaderiasResponse,
                formaEntrega = new FormaEntregaResponse
                {
                    id = comanda.FormaEntregaId,
                    descripcion = comanda.FormaEntrega.Descripcion
                },
                
                total = comanda.PrecioTotal,
                fecha = comanda.Fecha,
            };
        }

        public ComandaResponse CreateComanda(ComandaRequest request)
        {
            int precioTotal = 0;

            List<Mercaderia> mercaderiasComanda = request.mercaderias.Select(_mercaderiaQuery.GetMercaderiaById).ToList();

            List<MercaderiaComandaResponse> mercaderiasResponse = mercaderiasComanda

                .Select(x => new MercaderiaComandaResponse
                {
                    id = x.MercaderiaId,
                    nombre = x.Nombre,
                    precio = x.Precio,

                }).ToList();

            precioTotal = mercaderiasComanda.Sum(x => x.Precio);

            var comanda = new Comanda
            {
                PrecioTotal = precioTotal,
                Fecha = DateTime.Now.Date,
                FormaEntregaId = request.formaEntrega,
                FormaEntrega = _formaEntregaQuery.GetFormaEntregaById(request.formaEntrega),
            };
            _command.InsertComanda(comanda);

            foreach(var mer in mercaderiasComanda)
            {
                _comandaMercaderiaService.CreateComandaMercaderia(comanda, mer);
            }

            return new ComandaResponse
            {
                id = comanda.ComandaId,
                mercaderias = mercaderiasResponse,
                formaEntrega = new FormaEntregaResponse
                {
                    id = comanda.FormaEntregaId,
                    descripcion = comanda.FormaEntrega.Descripcion
                },
                total = comanda.PrecioTotal,
                fecha = comanda.Fecha,
            };
        }

        public Comanda RemoveComanda(Guid comandaId)
        {
            return _command.RemoveComanda(comandaId);
        }

        public Comanda UpdateComanda(Guid comandaId)
        {
            return _command.UpdateComanda(comandaId);
        }
    }
}

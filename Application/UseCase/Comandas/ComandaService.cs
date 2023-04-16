using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase.Comandas
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaCommand _command;
        private readonly IComandaQuery _query;

        public ComandaService(IComandaCommand command, IComandaQuery query)
        {
            _command = command;
            _query = query;
        }

        public Comanda GetComandaById(Guid comandaId)
        {
            return _query.GetComandaById(comandaId);
        }

        public List<Comanda> GetComandaList()
        {
            return _query.GetComandaList();
        }

        public Comanda CreateComanda(int precioTotal, DateTime fecha, FormaEntrega formaEntrega)
        {
            var comanda = new Comanda
            {
                PrecioTotal = precioTotal,
                Fecha = fecha,
                FormaEntrega = formaEntrega,
                FormaEntregaId = formaEntrega.FormaEntregaId
            };

            return _command.InsertComanda(comanda);
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

using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase.ComandasMercaderias
{
    public class ComandaMercaderiaService : IComandaMercaderiaService
    {
        private readonly IComandaMercaderiaCommand _command;
        private readonly IComandaMercaderiaQuery _query;

        public ComandaMercaderiaService(IComandaMercaderiaCommand command, IComandaMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public ComandaMercaderia GetComandaMercaderiaById(int comandaMercaderiaId)
        {
            return _query.GetComandaMercaderiaById(comandaMercaderiaId);
        }

        public List<ComandaMercaderia> GetComandaMercaderiaList()
        {
            return _query.GetComandaMercaderiaList();
        }

        public ComandaMercaderia CreateComandaMercaderia(Mercaderia mercaderia, Comanda comanda)
        {
            var comandaMercaderia = new ComandaMercaderia
            {
                Mercaderia = mercaderia,
                MercaderiaId = mercaderia.MercaderiaId,
                Comanda = comanda,
                ComandaId = comanda.ComandaId
            };

            return _command.InsertComandaMercaderia(comandaMercaderia);
        }

        public ComandaMercaderia RemoveComandaMercaderia(int comandaMercaderiaId)
        {
            return _command.RemoveComandaMercaderia(comandaMercaderiaId);
        }

        public ComandaMercaderia UpdateComandaMercaderia(int comandaMercaderiaId)
        {
            return _command.UpdateComandaMercaderia(comandaMercaderiaId);
        }
    }
}

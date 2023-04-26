using Domain.Entities;

namespace Application.Response
{
    public class ComandaResponse
    {
        public Guid id { set; get; }
        public List<MercaderiaComandaResponse> mercaderias { get; set; }
        public FormaEntregaResponse formaEntrega { get; set; }
        public int total { set; get; }
        public DateTime fecha { set; get; }
    }
}

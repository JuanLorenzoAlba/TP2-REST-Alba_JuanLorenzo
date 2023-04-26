using Domain.Entities;

namespace Application.Response
{
    public class ComandaGetResponse
    {
        public Guid id { set; get; }
        public ICollection<MercaderiaGetResponse> mercaderias { get; set; }
        public FormaEntrega formaEntrega { get; set; }
        public int total { set; get; }
        public DateTime fecha { set; get; }
    }
}

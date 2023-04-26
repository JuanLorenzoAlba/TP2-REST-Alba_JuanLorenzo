namespace Application.Response
{
    public class ComandaGetResponse
    {
        public Guid Id { set; get; }
        public ICollection<MercaderiaGetResponse> Mercaderias { get; set; }
        public FormaEntregaResponse FormaEntrega { get; set; }
        public int Total { set; get; }
        public DateTime Fecha { set; get; }
    }
}

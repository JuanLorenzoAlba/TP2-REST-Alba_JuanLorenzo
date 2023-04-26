namespace Application.Response
{
    public class ComandaResponse
    {
        public Guid Id { set; get; }
        public List<MercaderiaComandaResponse> Mercaderias { get; set; }
        public FormaEntregaResponse FormaEntrega { get; set; }
        public int Total { set; get; }
        public DateTime Fecha { set; get; }
    }
}

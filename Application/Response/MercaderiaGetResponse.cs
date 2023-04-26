namespace Application.Response
{
    public class MercaderiaGetResponse
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public int precio { get; set; }
        public TipoMercaderiaResponse tipo { set; get; }
        public string imagen { set; get; }
    }
}

namespace Application.Response
{
    public class MercaderiaResponse
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public TipoMercaderiaResponse tipo { set; get; }
        public int precio { get; set; }
        public string ingredientes { set; get; }
        public string preparacion { set; get; }
        public string imagen { set; get; }
    }
}

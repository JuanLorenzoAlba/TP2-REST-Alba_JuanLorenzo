namespace Application.Request
{
    public class MercaderiaRequest
    {
        public string nombre { set; get; }
        public int tipo { set; get; }
        public int precio { get; set; }
        public string ingredientes { set; get; }
        public string preparacion { set; get; }
        public string imagen { set; get; }
    }
}

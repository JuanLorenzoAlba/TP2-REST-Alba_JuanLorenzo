namespace Application.Request
{
    public class MercaderiaRequest
    {
        public string Nombre { set; get; }
        public int Tipo { set; get; }
        public int Precio { get; set; }
        public string Ingredientes { set; get; }
        public string Preparacion { set; get; }
        public string Imagen { set; get; }
    }
}

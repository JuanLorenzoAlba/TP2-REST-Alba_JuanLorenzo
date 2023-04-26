namespace Application.Response
{
    public class MercaderiaResponse
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public TipoMercaderiaResponse Tipo { set; get; }
        public int Precio { get; set; }
        public string Ingredientes { set; get; }
        public string Preparacion { set; get; }
        public string Imagen { set; get; }
    }
}

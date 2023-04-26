namespace Application.Response
{
    public class MercaderiaGetResponse
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public int Precio { get; set; }
        public TipoMercaderiaResponse Tipo { set; get; }
        public string Imagen { set; get; }
    }
}

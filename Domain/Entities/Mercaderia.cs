namespace Domain.Entities
{
    public class Mercaderia
    {
        public int MercaderiaId { set; get; }
        public string Nombre { set; get; }
        public int Precio { set; get; }
        public string Ingredientes { set; get; }
        public string Preparacion { set; get; }
        public string Imagen { set; get; }

        public int TipoMercaderiaId { get; set; }
        public TipoMercaderia TipoMercaderia { set; get; }

        public ICollection<ComandaMercaderia> ComandasMercaderias { get; set; }
    }
}

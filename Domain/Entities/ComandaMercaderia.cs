namespace Domain.Entities
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { set; get; }

        public int MercaderiaId { set; get; }
        public Mercaderia Mercaderia { set; get; }

        public Guid ComandaId { set; get; }
        public Comanda Comanda { set; get; }
    }
}
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFormaEntregaCommand
    {
        FormaEntrega InsertFormaEntrega(FormaEntrega formaEntrega);
        FormaEntrega RemoveFormaEntrega(int formaEntregaId);
        FormaEntrega UpdateFormaEntrega(int formaEntregaId);
    }
}

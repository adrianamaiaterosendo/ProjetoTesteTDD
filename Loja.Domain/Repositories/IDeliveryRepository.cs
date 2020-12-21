using Loja.Domain.Entities;

namespace Loja.Domain.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        decimal Get (string zipCode);
        
    }
}
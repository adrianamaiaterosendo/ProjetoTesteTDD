using Loja.Domain.Entities;
using Loja.Domain.Repositories.Interfaces;

namespace Loja.Testes.Repositories
{
    public class FakeDeliveryRepository : IDeliveryRepository
    {
        public decimal Get (string zipCode){
            return 10;
        }
    }
}
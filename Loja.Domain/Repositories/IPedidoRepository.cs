using Loja.Domain.Entities;


namespace Loja.Domain.Repositories.Interfaces
{
    public interface IPedidoRepository
    {

        void Save (Pedido pedido);
        
    }
}
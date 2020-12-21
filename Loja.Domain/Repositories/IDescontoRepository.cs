using Loja.Domain.Entities;

namespace Loja.Domain.Repositories.Interfaces
{
    public interface IDescontoRepository
    {
        Desconto Get (string code);
        
    }
}
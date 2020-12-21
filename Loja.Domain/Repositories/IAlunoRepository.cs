using Loja.Domain.Entities;

namespace Loja.Domain.Repositories.Interfaces
{
    public interface IAlunoRepository
    {

        Aluno Get (string document);

        
    }
}
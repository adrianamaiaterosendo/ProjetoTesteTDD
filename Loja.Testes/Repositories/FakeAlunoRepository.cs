using Loja.Domain.Entities;
using Loja.Domain.Repositories.Interfaces;

namespace Loja.Testes.Repositories
{
    public class FakeAlunoRepository : IAlunoRepository
    {
        public Aluno Get (string document){
            if(document == "12345678911"){
                return new Aluno ("Regina Maria", "regina@maria.teste");
            } return null;
        }
        
    }
}
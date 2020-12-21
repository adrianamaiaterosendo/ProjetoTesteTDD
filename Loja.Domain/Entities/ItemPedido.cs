using Flunt.Validations;

namespace Loja.Domain.Entities
{
    public class ItemPedido : Entity
    {
        public ItemPedido(Curso curso, int quantidade)
        {

               AddNotifications(
                    new Contract()
                    .Requires()
                    .IsNotNull(curso, "Curso", "Curso inválido")
                    .IsGreaterThan(quantidade, 0, "Quantidade", "A quantidade deve ser maior que 0")
                    

            );
            Curso = curso;
            Preco = Curso != null ? curso.Preco : 0;
            Quantidade = quantidade;
        }

        public Curso Curso {get; private set;}
        public decimal Preco {get; private set;}
        public int Quantidade {get; private set;}

        public decimal Total(){
            return Preco * Quantidade;
        }
        
    }
}
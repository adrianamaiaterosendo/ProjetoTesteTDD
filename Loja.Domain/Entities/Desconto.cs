using System;

namespace Loja.Domain.Entities
{
    public class Desconto : Entity
    {
        public Desconto(decimal valorDesconto, DateTime dataExpiracao)
        {
            ValorDesconto = valorDesconto;
            DataExpiracao = dataExpiracao;
        }

        public decimal ValorDesconto {get; private set;}

        public DateTime DataExpiracao {get; private set;}


        public bool EValido(){
            return DateTime.Compare(DateTime.Now, DataExpiracao) < 0;
        }
        

        public decimal Valor(){

            if(EValido())
            return ValorDesconto;
            else
            return 0;

        }
    }
}
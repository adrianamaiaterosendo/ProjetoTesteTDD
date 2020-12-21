namespace Loja.Domain.Entities
{
    public class Curso : Entity
    {
        public Curso(string titulo, decimal preco, bool ativo)
        {
            Titulo = titulo;
            Preco = preco;
            Ativo = ativo;
        }

        public string Titulo {get; private set;}
        public decimal Preco {get; private set;}
        public bool Ativo {get; private set;}
        
    }
}
namespace Loja.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name {get; private set;}
        public string Email {get; private set;}
        
    }
}
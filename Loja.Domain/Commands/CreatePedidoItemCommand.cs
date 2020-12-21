using System;
using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Commands.Interfaces;

namespace Loja.Domain.Commands
{
    public class CreatePedidoItemCommand : Notifiable, ICommand
    {

        public CreatePedidoItemCommand(){}

        public CreatePedidoItemCommand(Guid curso, int quantidade){

            Curso = curso;
            Quantidade = quantidade; 
            
        }

        public Guid Curso {get; set;}

        public int Quantidade {get; set;}

        public void validate(){
            AddNotifications(new Contract()
            .Requires()
            .HasLen(Curso.ToString(), 32, "Curso", "Curso inválido")
            .IsGreaterThan(Quantidade, 0, "Quantidade","Quantidade Invalida")
            
            );
        }


    }
}
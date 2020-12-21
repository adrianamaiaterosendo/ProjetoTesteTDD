using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Commands.Interfaces;

namespace Loja.Domain.Commands
{
    public class CreatePedidoCommand: Notifiable, ICommand
    {
        public CreatePedidoCommand()
        {
            Items = new List<CreatePedidoItemCommand>();
        }

        public CreatePedidoCommand(string aluno, string zipCode, string promoCode, IList<CreatePedidoItemCommand> items)
        {
            Aluno = aluno;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Aluno { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreatePedidoItemCommand> Items { get; set; }

        public void validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Aluno, 11, "Aluno", "Aluno inválido")
                .HasLen(ZipCode, 8, "ZipCode", "CEP inválido")
            );
        }
    }
}

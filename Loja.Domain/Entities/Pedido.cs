using System;
using System.Collections.Generic;
using Flunt.Validations;
using Loja.Domain.Enums;

namespace Loja.Domain.Entities
{
    public class Pedido :Entity
    {
        public Pedido(Aluno aluno, decimal delivery, Desconto desconto)
        {
            AddNotifications(
                    new Contract()
                    .Requires()
                    .IsNotNull(aluno, "Aluno", "Aluno inválido")
                    

            );
            Aluno = aluno;
            Data = DateTime.Now;
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EStatusPedido.AguardandoPagamento;
            Delivery = delivery;
            Desconto = desconto;
            Items = new List<ItemPedido>();
        }

        public Aluno Aluno {get; private set;}
        public DateTime Data {get; private set;}
        public string Numero{get; private set;}
        public IList<ItemPedido> Items {get; private set;}
        public decimal Delivery {get; private set;}
        public Desconto Desconto {get; private set;}

        public EStatusPedido Status {get; private set;}

        public void AddItem (Curso curso, int quantidade){
            var item = new ItemPedido (curso, quantidade);
            if (item.Valid)
            Items.Add(item);
            }
        public decimal Total(){
            decimal total = 0;
            foreach (var item in Items){
                total += item.Total();
            }

            total += Delivery;
            total -= Desconto != null ? Desconto.Valor() : 0;

            return total;
        }

        public void Pagamento (decimal preco ){
            if(preco == Total())
            this.Status = EStatusPedido.AguardandoEntrega;
        }

        public void Cancel(){
            Status = EStatusPedido.Cancelado;
        }

        
    }
}
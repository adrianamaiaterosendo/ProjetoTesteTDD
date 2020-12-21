using System;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Loja.Testes.Entities
{
    [TestClass]
    public class PedidoTestes
    {

        private readonly Aluno _aluno = new Aluno("Adriana Maiate", "adriana@teste.com.br");
        private readonly Curso _curso = new Curso("Dotnet",50,true);
        private readonly Desconto _desconto = new Desconto (10, DateTime.Now.AddDays(5));

        private readonly Desconto _descontoExpirado = new Desconto (100, DateTime.Now.AddDays(-5));

        Curso c1 = new Curso("Java", 100, true);
        private readonly ItemPedido _itemPedido = new ItemPedido(null , 10);


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_numero_com_8_caracteres(){
            Pedido pedido = new Pedido(_aluno, 500, _desconto);
            Assert.AreEqual(8, pedido.Numero.Length);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardandopagamento(){
            Pedido pedido = new Pedido(_aluno, 500, null);
            Assert.AreEqual(pedido.Status, EStatusPedido.AguardandoPagamento);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_pedido_seu_status_deve_ser_aguardandoentrega(){
            Pedido pedido = new Pedido(_aluno, 500, null);
            pedido.Pagamento(500);
            Assert.AreEqual(pedido.Status, EStatusPedido.AguardandoEntrega);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_status_deve_ser_cancelado(){
            Pedido pedido = new Pedido(_aluno, 500, null);
            pedido.Cancel();
            Assert.AreEqual(pedido.Status, EStatusPedido.Cancelado);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_pode_ser_adicionado(){
            Pedido pedido = new Pedido(_aluno, 500, null);
            pedido.AddItem(null, 10);
            Assert.AreEqual(pedido.Items.Count, 0);
                        
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado(){
            Pedido pedido = new Pedido(_aluno, 500, null);
            pedido.AddItem(_curso, 0);
            Assert.AreEqual(pedido.Items.Count, 0);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_100(){
            Pedido pedido = new Pedido(_aluno, 50, null);
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Total(), 100);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_100(){
            Pedido pedido = new Pedido(_aluno, 50, _descontoExpirado);
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Total(), 100);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_seu_total_do_pedido_deve_ser_100(){
            Pedido pedido = new Pedido(_aluno, 50, null);         
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Total(), 100);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_total_do_pedido_deve_ser_90(){
            Pedido pedido = new Pedido(_aluno, 50, _desconto);         
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Total(), 90);
                        
        }

        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_60_valor_do_pedido_deve_ser_100(){
            Pedido pedido = new Pedido(_aluno, 60, _desconto);         
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Total(), 100);
                        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido(){
            Pedido pedido = new Pedido(null, 60, _desconto);         
            pedido.AddItem(_curso, 1);
            Assert.AreEqual(pedido.Valid, false);
                        
        }
    }
}
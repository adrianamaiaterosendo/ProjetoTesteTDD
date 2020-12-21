using System;
using System.Collections.Generic;
using System.Linq;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.Queries;
using Loja.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Testes.Commands
{
    [TestClass]
    public class CreateOrderCommandTestes
    {
        [TestMethod]
        [TestCategory("Handlers")]

        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado(){
            var command = new CreatePedidoCommand();
            command.Aluno = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreatePedidoItemCommand(Guid.NewGuid(),1));
            command.Items.Add(new CreatePedidoItemCommand(Guid.NewGuid(),1));
            command.validate();

            Assert.AreEqual(command.Valid, false);
        }

        
    }
}
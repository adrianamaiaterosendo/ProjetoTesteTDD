using System.Linq;
using Flunt.Notifications;
using Loja.Domain.Commands;
using Loja.Domain.Commands.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Handlers.Interfaces;
using Loja.Domain.Repositories.Interfaces;


namespace Loja.Domain.Handlers
{
    public class PedidoHandler :
        Notifiable,
        IHandler<CreatePedidoCommand>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDescontoRepository _descontoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(
            IAlunoRepository alunoRepository,
            IDeliveryRepository deliveryRepository,
            IDescontoRepository descontoRepository,
            ICursoRepository cursoRepository,
            IPedidoRepository pedidoRepository)
        {
            _alunoRepository = alunoRepository;
            _deliveryRepository = deliveryRepository;
            _descontoRepository = descontoRepository;
            _cursoRepository = cursoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public ICommandResult Handle(CreatePedidoCommand command)
        {
            // Fail Fast Validation
            command.validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Pedido inválido", null);

            // 1. Recupera o cliente
            var aluno = _alunoRepository.Get(command.Aluno);

            // 2. Calcula a taxa de entrega
            var delivery = _deliveryRepository.Get(command.ZipCode);

            // 3. Obtém o cupom de desconto
            var desconto = _descontoRepository.Get(command.PromoCode);

            // 4. Gera o pedido
            var cursos = _cursoRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var pedido = new Pedido(aluno, delivery, desconto);
            foreach (var item in command.Items)
            {
                var curso = cursos.Where(x => x.Id == item.Curso).FirstOrDefault();
                pedido.AddItem(curso, item.Quantidade);
            }

            // 5. Agrupa as notificações
            AddNotifications(pedido.Notifications);

            // 6. Verifica se deu tudo certo
            if (Invalid)
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

            // 7. Retorna o resultado
            _pedidoRepository.Save(pedido);
            return new GenericCommandResult(true, $"Pedido {pedido.Numero} gerado com sucesso", pedido);
        }
    }
}

using Loja.Domain.Commands.Interfaces;

namespace Loja.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
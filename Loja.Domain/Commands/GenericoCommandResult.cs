using Loja.Domain.Commands.Interfaces;

namespace Loja.Domain.Commands
{
    public class GenericoCommandResult : ICommandResult
    {
        public GenericoCommandResult(bool success, string message, object data){
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success{get; set;}
        public string Message{get; set;}
        public object Data{get; set;}
        
    }
}
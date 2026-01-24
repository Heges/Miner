using MinerDomain.Interfaces;

namespace Miner.Services
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<Type, object> _handlesMap = new();

        public TResult Process<TCommand, TResult>(TCommand command) 
            where TCommand : ICommand<TResult>
        {
            if (_handlesMap.TryGetValue(typeof(TCommand), out var handler))
            {
                var typedHandler = (ICommandHandler<TCommand, TResult>)handler;
                var result = typedHandler.Handle(command);
                return result;
            }

            throw new InvalidOperationException($"No handler registered for {typeof(TCommand).Name}");
        }

        public void RegisterHandler<TCommand, TResult>(ICommandHandler<TCommand, TResult> handler)
            where TCommand : ICommand<TResult>
        {
            _handlesMap[typeof(TCommand)] = handler;
        }
    }
}

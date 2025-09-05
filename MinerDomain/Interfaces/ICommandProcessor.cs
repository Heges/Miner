namespace MinerDomain.Interfaces
{
    public interface ICommandProcessor
    {
        public void RegisterHandler<TCommand, TResult>(ICommandHandler<TCommand, TResult> handler) 
            where TCommand : ICommand<TResult>;
        TResult Process<TCommand, TResult>(TCommand command) 
            where TCommand : ICommand<TResult>;
    }
}

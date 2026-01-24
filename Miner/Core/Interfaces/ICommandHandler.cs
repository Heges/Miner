namespace MinerDomain.Interfaces
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        TResult Handle(TCommand command);
    }
}

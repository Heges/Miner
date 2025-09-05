namespace MinerDomain.Interfaces
{
    public interface ICommand<TResult>
    {
        TResult Execute();
    }
}

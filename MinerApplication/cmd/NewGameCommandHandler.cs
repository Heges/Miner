using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class NewGameCommandHandler : ICommandHandler<NewGameCommand, bool>
    {
        public bool Handle(NewGameCommand command)
        {
            return command.Execute();
        }
    }
}

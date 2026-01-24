using MinerApplication.cmd;
using MinerDomain.Interfaces;

namespace Miner.Services.Handlers
{
    public class NewGameCommandHandler : ICommandHandler<NewGameCommand, bool>
    {
        public bool Handle(NewGameCommand command)
        {
            return command.Execute();
        }
    }
}

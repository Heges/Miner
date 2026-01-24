using MinerApplication.cmd;
using MinerDomain.Interfaces;

namespace Miner.Services.Handlers
{
    public class GameOverHandler : ICommandHandler<GameOverCommand, bool>
    {
        public bool Handle(GameOverCommand command)
        {
            return command.Execute();
        }
    }
}

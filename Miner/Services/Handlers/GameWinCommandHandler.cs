using MinerDomain.Interfaces.cmd;
using MinerDomain.Interfaces;
using MinerApplication.cmd;

namespace Miner.Services.Handlers
{
    public class GameWinCommandHandler : ICommandHandler<GameWinCommand, bool>
    {
        public bool Handle(GameWinCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

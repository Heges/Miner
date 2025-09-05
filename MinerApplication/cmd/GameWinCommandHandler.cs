using MinerDomain.Interfaces.cmd;
using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class GameWinCommandHandler : ICommandHandler<GameWinCommand, bool>
    {
        public bool Handle(GameWinCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

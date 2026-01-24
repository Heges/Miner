using MinerApplication.cmd;
using MinerDomain.Interfaces;

namespace Miner.Services.Handlers
{
    public class ReShuffleGameBoardHandler : ICommandHandler<ReShuffleGameBoardCommand, bool>
    {
        public bool Handle(ReShuffleGameBoardCommand command)
        {
            return command.Execute();
        }
    }
}

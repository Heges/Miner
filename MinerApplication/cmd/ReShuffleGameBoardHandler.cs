using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class ReShuffleGameBoardHandler : ICommandHandler<ReShuffleGameBoardCommand, bool>
    {
        public bool Handle(ReShuffleGameBoardCommand command)
        {
            return command.Execute();
        }
    }
}

using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class GameOverHandler : ICommandHandler<GameOverCommand, bool>
    {
        public bool Handle(GameOverCommand command)
        {
            return command.Execute();
        }
    }
}

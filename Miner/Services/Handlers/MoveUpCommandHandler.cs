using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;

namespace Miner.Services.Handlers
{
    public class MoveUpCommandHandler : ICommandHandler<MoveUpCommand, bool>
    {
        private readonly IGameState _gameState;

        public MoveUpCommandHandler(IGameState gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(MoveUpCommand command)
        {
            var step = command.Execute();
            if (step)
                _gameState.Steps++;
            return step;
        }
    }
}

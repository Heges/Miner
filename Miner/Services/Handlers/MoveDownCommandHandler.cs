using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;

namespace Miner.Services.Handlers
{
    public class MoveDownCommandHandler : ICommandHandler<MoveDownCommand, bool>
    {
        private readonly IGameState _gameState;

        public MoveDownCommandHandler(IGameState gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(MoveDownCommand command)
        {
            var step = command.Execute();
            if (step)
                _gameState.Steps++;
            return step;
        }
    }
}

using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;

namespace Miner.Services.Handlers
{
    public class MoveLefttCommandHandler : ICommandHandler<MoveLefttCommand, bool>
    {
        private readonly IGameState _gameState;

        public MoveLefttCommandHandler(IGameState gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(MoveLefttCommand command)
        {
            var step = command.Execute();
            if (step)
                _gameState.Steps++;
            return step;
        }
    }
}

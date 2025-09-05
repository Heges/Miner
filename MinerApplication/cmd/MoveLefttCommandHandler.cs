namespace MinerDomain.Interfaces.cmd
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

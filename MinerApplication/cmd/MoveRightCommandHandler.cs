namespace MinerDomain.Interfaces.cmd
{
    public class MoveRightCommandHandler : ICommandHandler<MoveRightCommand, bool>
    {
        private readonly IGameState _gameState;

        public MoveRightCommandHandler(IGameState gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(MoveRightCommand command)
        {
            var step = command.Execute();
            if (step)
                _gameState.Steps++;
            return step;
        }
    }
}

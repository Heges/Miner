namespace MinerDomain.Interfaces.cmd
{
    public class PlaceFlagCommandHandler : ICommandHandler<PlaceFlagCommand, bool>
    {
        private readonly IGameState _gameState;

        public PlaceFlagCommandHandler(IGameState gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(PlaceFlagCommand command)
        {
            var step = command.Execute();
            if (step)
                _gameState.Flags++;
            else 
                _gameState.Flags--;
                return step;
        }
    }
}

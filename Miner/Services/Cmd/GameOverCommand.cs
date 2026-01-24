using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class GameOverCommand : ICommand<bool>
    {
        private readonly IGameState _settings;
        private readonly BoardService _boardService;

        public GameOverCommand(IGameState settings,
            BoardService boardService)
        {
            _settings = settings;
            _boardService = boardService;
        }

        public bool Execute()
        {
            _boardService.Habibi(true);
            return true;
        }
    }
}

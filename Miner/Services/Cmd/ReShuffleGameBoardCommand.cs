using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class ReShuffleGameBoardCommand : ICommand<bool>
    {
        private readonly IGameState _settings;
        private readonly BoardService _boardService;
        private readonly int _x;
        private readonly int _y;

        public ReShuffleGameBoardCommand(IGameState settings, BoardService boardService, int x, int y)
        {
            _settings = settings;
            _boardService = boardService;
            _x = x;
            _y = y;
        }

        public bool Execute()
        {
            _boardService.ResetByDefault();
            _boardService.SetMinesToGameBoard(_x, _y, _settings.BombCount);
            _boardService.CountMinesAround();
            _boardService.Reveal();
            return true;
        }
    }
}

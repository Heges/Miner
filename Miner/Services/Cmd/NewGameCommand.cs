using System.Runtime;
using MinerDomain.Interfaces;

namespace MinerApplication.cmd
{
    public class NewGameCommand : ICommand<bool>
    {
        private readonly IGameState _settings;
        private readonly BoardService _boardService;

        public NewGameCommand(IGameState settings, BoardService boardService)
        {
            _settings = settings;
            _boardService = boardService;
        }

        public bool Execute()
        {
            _settings.Timer = 0;
            _settings.Steps = 0;
            _settings.Flags = 0;
            _boardService.ResetByDefault();
            _boardService.SetMinesToGameBoard(count:_settings.BombCount);
            _boardService.CountMinesAround();
            _boardService.SetCursor(_settings.InitialCursorPositionX, _settings.InitialCursorPositionY);
            return true;
        }
    }
}

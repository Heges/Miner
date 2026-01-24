using Miner.Core.Interfaces;
using MinerDomain;
using MinerDomain.Interfaces;

namespace Miner.UI
{
    public class ConsoleUI : IUIView
    {
        private readonly IGameBoardRenderer _renderer;
        private readonly IGameState _settings;
        private readonly GameBoard _board;

        public ConsoleUI(IGameBoardRenderer renderer,  GameBoard board, IGameState settings)
        {
            _renderer = renderer;
            _board = board;
            _settings = settings;
        }

        public void Draw()
        {
            _renderer.Render(_board, _settings.IsGameOver, _settings.IsGameWin, (int)_settings.Timer, _settings.Steps, _settings.Flags);
        }
    }
}

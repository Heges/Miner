using System.Diagnostics;
using MinerApplication;
using MinerApplication.cmd;
using MinerDomain;
using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;

namespace Miner
{
    public class GameService : IGame
    {
        private bool _isFirstReveal = false;
        private readonly IController _controller;
        private readonly ICommandProcessor _commandProcessor;
        private readonly IUIView _ui;
        private readonly IGameState _gameSettings;
        private readonly BoardService _boardService;
        private readonly Stopwatch _timer;

        public GameService(IGameState gameSettings,
            IController controller,
            IUIView ui,
            BoardService boardService,
            ICommandProcessor commandProcessor
            )
        {
            _gameSettings = gameSettings;
            _ui = ui;
            _boardService = boardService;
            _controller = controller;
            _commandProcessor = commandProcessor;

            _isFirstReveal = true;

            _timer = new Stopwatch();

            NewGame();
        }

        public bool NewGame()
        {
            _timer.Stop();
            _timer.Reset();
            _timer.Start();

            _gameSettings.IsGameOver = false;
            _isFirstReveal = true;

            var newGame = new NewGameCommand(_gameSettings, _boardService);

            _commandProcessor.Process<NewGameCommand, bool>(newGame);

            _ui.Draw();

            return true;
        }

        public bool Update()
        {
            _gameSettings.Timer = _timer.Elapsed.TotalSeconds;

            if (_gameSettings.IsGameOver || _gameSettings.IsGameWin)
            {
                Thread.Sleep(3000);
                NewGame();
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    var moveUp = new MoveUpCommand(_controller);

                    var result = _commandProcessor.Process<MoveUpCommand, bool>(moveUp);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    var moveDown = new MoveDownCommand(_controller);

                    var result = _commandProcessor.Process<MoveDownCommand, bool>(moveDown);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    var moveLeft = new MoveLefttCommand(_controller);

                    var result = _commandProcessor.Process<MoveLefttCommand, bool>(moveLeft);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    var moveRight = new MoveRightCommand(_controller);

                    var result = _commandProcessor.Process<MoveRightCommand, bool>(moveRight);
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    var openCell = new OpenCellCommand(_controller);

                    var result = _commandProcessor.Process<OpenCellCommand, Cell>(openCell);

                    if (result.IsBomb && !result.IsMarked)
                    {
                        if (_isFirstReveal)
                        {
                            var shuffleCommand = new ReShuffleGameBoardCommand(_gameSettings,
                                _boardService,
                                result.PositionX,
                                result.PositionY
                                );

                            _commandProcessor.Process<ReShuffleGameBoardCommand, bool>(shuffleCommand);
                        }
                        else
                        {
                            GameOver();
                        }
                    }
                    else
                    {
                        _isFirstReveal = false;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    var placeFlag = new PlaceFlagCommand(_controller);

                    var result = _commandProcessor.Process<PlaceFlagCommand, bool>(placeFlag);
                }
            }
            _gameSettings.IsGameWin = _boardService.Victory();

            _ui.Draw();

            Thread.Sleep(100);

            return true;
        }

        public bool GameOver()
        {
            var gameOver = new GameOverCommand(_gameSettings, _boardService);

            var gameOverResult = _commandProcessor.Process<GameOverCommand, bool>(gameOver);

            _gameSettings.IsGameOver = gameOverResult;

            return gameOverResult;
        }
    }
}

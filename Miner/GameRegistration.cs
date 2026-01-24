using Container;
using Miner.Services;
using Miner.Services.Handlers;
using Miner.UI;
using MinerApplication;
using MinerDomain;
using MinerDomain.Interfaces;

namespace Miner
{
    public static class GameRegistration
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(_ =>
            {
                var settings = container.Resolve<GameState>();
                return new GameBoard(settings.Width, settings.Height);
            }).AsSingle();

            container.RegisterFactory(_ =>
            {
                var board = container.Resolve<GameBoard>();
                return new BoardService(board);
            }).AsSingle();

            container.RegisterFactory(_ =>
            {
                var boardService = container.Resolve<BoardService>();
                return new MovingController(boardService);
            });

            container.RegisterFactory(_ => new GameBoardRenderer());

            container.RegisterFactory(_ =>
            {
                var settings = container.Resolve<GameState>();
                var consoleRenderer = container.Resolve<GameBoardRenderer>();
                var gameBoard = container.Resolve<GameBoard>();
                return new ConsoleUI(consoleRenderer, gameBoard, settings);
            });

            container.RegisterFactory<ICommandProcessor>(_ => new CommandProcessor())
                .AsSingle();

            container.RegisterFactory<IGameRoot>(_ =>
            {
                var settings = container.Resolve<GameState>();
                var consoleController = container.Resolve<MovingController>();
                var consoleUI = container.Resolve<ConsoleUI>();
                var boardService = container.Resolve<BoardService>();

               ICommandProcessor _commandProcessor = container.Resolve<ICommandProcessor>();

                var moveDownHandler = new MoveDownCommandHandler(settings);
                var moveUpHandler = new MoveUpCommandHandler(settings);
                var moveLeftHandler = new MoveLefttCommandHandler(settings);
                var moveRightHandler = new MoveRightCommandHandler(settings);
                var openCellHandler = new OpenCellCommandHandler();
                var placeFlagHandler = new PlaceFlagCommandHandler(settings);
                var newGameHandler = new NewGameCommandHandler();
                var gameOverHandler = new GameOverHandler();
                var reshuffleGameBoard = new ReShuffleGameBoardHandler();

                _commandProcessor.RegisterHandler(moveDownHandler);
                _commandProcessor.RegisterHandler(moveUpHandler);
                _commandProcessor.RegisterHandler(moveLeftHandler);
                _commandProcessor.RegisterHandler(moveRightHandler);
                _commandProcessor.RegisterHandler(openCellHandler);
                _commandProcessor.RegisterHandler(placeFlagHandler);
                _commandProcessor.RegisterHandler(newGameHandler);
                _commandProcessor.RegisterHandler(gameOverHandler);
                _commandProcessor.RegisterHandler(reshuffleGameBoard);

                return new GameService(settings, consoleController, consoleUI, boardService, _commandProcessor);
            });
        }
    }
}

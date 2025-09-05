using Container;
using MinerApplication;
using MinerApplication.cmd;
using MinerDomain;
using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;
using MinerInfrastructure;

namespace Miner
{
    public static class GameRegistration
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(_ =>
            {
                var settings = container.Resolve<GameSettings>();
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
                return new ConsoleController(boardService);
            });

            container.RegisterFactory(_ => new ConsoleRenderer());

            container.RegisterFactory(_ =>
            {
                var settings = container.Resolve<GameSettings>();
                var consoleRenderer = container.Resolve<ConsoleRenderer>();
                var gameBoard = container.Resolve<GameBoard>();
                return new ConsoleUI(consoleRenderer, gameBoard, settings);
            });

            container.RegisterFactory<ICommandProcessor>(_ => new CommandProcessor())
                .AsSingle();

            container.RegisterFactory<IGame>(_ =>
            {
                var settings = container.Resolve<GameSettings>();
                var consoleController = container.Resolve<ConsoleController>();
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

using Container;
using Miner.Services;

namespace Miner
{
    public class Program
    {
        static void Main(string[] args)
        {
            DIContainer _rootContainer = new();

            int width = 12;
            int height = 12;
            int bombCount = (int)(width * height * 0.1f);

            var settings = new GameState()
            {
                CurrentLevelId = 1,
                Timer = 00.00f,
                Width = width,
                Height = height,
                BombCount = bombCount,
                InitialCursorPositionX = 1,
                InitialCursorPositionY = 1,
            };

            _rootContainer.RegisterInstance<GameState>(settings);
            _rootContainer.RegisterFactory(_ => new GameEntryPoint(_rootContainer))
                .AsSingle();

            var gameEntryPoint = _rootContainer.Resolve<GameEntryPoint>();

            var gameIsRunning = true;

            while (gameIsRunning)
            {
                gameIsRunning = gameEntryPoint.Update();
            }

        }

    }
}

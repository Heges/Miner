using Container;
using MinerInfrastructure;

namespace Miner
{
    public class Program
    {
        private static DIContainer _rootContainer = new();

        static void Main(string[] args)
        {
            int width = 12;
            int height = 12;
            int bombCount = (int)(width * height * 0.1f);

            var settings = new GameSettings()
            {
                CurrentLevelId = 1,
                Timer = 00.00f,
                Width = width,
                Height = height,
                BombCount = bombCount,
                InitialCursorPositionX = 1,
                InitialCursorPositionY = 1,
            };

            _rootContainer.RegisterInstance<GameSettings>(settings);
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

using Container;
using MinerDomain.Interfaces;

namespace Miner
{
    public class GameEntryPoint
    {
        private readonly DIContainer _container;

        private readonly IGameRoot _gameService;

        public GameEntryPoint(DIContainer container)
        {
            _container = container;

            GameRegistration.Register(container);

            _gameService = container.Resolve<IGameRoot>();
        }

        public bool Update()
        {
            return _gameService.Update();
        }
    }
}

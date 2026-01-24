using MinerApplication;
using MinerDomain;
using MinerDomain.Interfaces;

namespace Miner.Services
{
    public class MovingController : IController
    {
        private readonly BoardService _boardService;

        public MovingController(BoardService board)
        {
            _boardService = board;
        }

        public bool MoveDown()
        {
            return _boardService.Move(0, 1);
        }

        public bool MoveLeft()
        {
            return _boardService.Move(-1, 0);
        }

        public bool MoveRight()
        {
            return _boardService.Move(1, 0);
        }

        public bool MoveUp()
        {
            return _boardService.Move(0, -1);
        }

        public Cell OpenCell()
        {
            return _boardService.Reveal();
        }

        public bool PlaceFlag()
        {
            return _boardService.Flag();
        }
    }
}

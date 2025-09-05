namespace MinerDomain.Interfaces
{
    public interface IController
    {
        public bool MoveRight();
        public bool MoveLeft();
        public bool MoveUp();
        public bool MoveDown();
        public Cell OpenCell();
        public bool PlaceFlag();
    }
}

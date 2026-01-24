namespace MinerDomain.Interfaces
{
    public interface IGameRoot
    {
        public bool NewGame();
        public bool Update();
        public bool GameOver();
    }
}

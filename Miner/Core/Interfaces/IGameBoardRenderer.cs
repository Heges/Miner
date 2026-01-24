namespace MinerDomain.Interfaces
{
    public interface IGameBoardRenderer
    {
        void Render(GameBoard board, bool isGameOver, bool isVictory, int elapsedSeconds, int steps, int flags, bool isDebug = false);
    }
}

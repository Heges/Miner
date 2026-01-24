namespace MinerDomain.Interfaces
{
    public interface IGameState
    {
        public int CurrentLevelId { get; set; }
        public double Timer { get; set; }
        public int Steps { get; set; }
        public int Flags { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int BombCount { get; set; }

        public int InitialCursorPositionX { get; set; }
        public int InitialCursorPositionY { get; set; }

        public int CurrentCursorPositionX { get; set; }
        public int CurrentCursorPositionY { get; set; }

        public bool IsGameOver { get; set; }
        public bool IsGameWin { get; set; }
    }
}

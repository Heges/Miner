namespace MinerDomain
{
    public class Cell
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool IsBomb { get; set; }
        public int BombsAround { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsMarked { get; set; }
        public bool Cursor {  get; set; }
    }
}

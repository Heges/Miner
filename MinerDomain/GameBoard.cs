namespace MinerDomain
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        public Cell[,] Cells { get; }

        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++) {
                    Cells[i, j] = new Cell()
                    {
                        PositionX = i,
                        PositionY = j,
                    };
                }
            }
        }
    }
}

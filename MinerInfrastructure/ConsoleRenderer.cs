using MinerDomain;
using MinerDomain.Interfaces;

namespace MinerInfrastructure
{
    public class ConsoleRenderer : IGameBoardRenderer
    {
        public void Render(GameBoard board, bool isGameOver, bool isVictory, int elapsedSeconds, int steps, int flags, bool isDebug = false)
        {
            Console.Clear();

            Console.WriteLine($"Time: {elapsedSeconds}s   Steps: {steps}   Flags: {flags}");

            if (isVictory && !isGameOver)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU WON!");
                Console.ResetColor();
            }
            else if (isGameOver && !isVictory)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BOOM! You hit a mine!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Use arrows to move. [SPACE] open | [BACKSPACE] flag");
            }

            Console.WriteLine();

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    var cell = board.Cells[x, y];
                    char symbol = ' ';
                    if (isDebug)
                    {
                        symbol = !(x == 0 || x == board.Width - 1 || y == 0 || y == board.Height - 1)
                        ? (cell.IsMarked ? '!' : cell.IsBomb ? '*' : (cell.BombsAround > 0 ? cell.BombsAround.ToString()[0] : ' '))
                        : '=';
                    }
                    symbol = !(x == 0 || x == board.Width - 1 || y == 0 || y == board.Height - 1)
                        ? (cell.IsMarked ? '!' : cell.IsRevealed ? (cell.IsBomb ? '*' : (cell.BombsAround > 0 ? cell.BombsAround.ToString()[0] : ' ')) : '.')
                        : '=';


                    if (cell.Cursor)
                    {
                        Console.Write($"[{symbol}]");
                    }
                    else
                    {
                        Console.Write($" {symbol} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

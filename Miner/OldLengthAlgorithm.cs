using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    public class OldLengthAlgorithm
    {
        public const int WIDTH = 12;
        public const int HEIGHT = 12;

        public static char[,] _gameBoard = new char[WIDTH, HEIGHT];
        public static char[,] _gameBoardView = new char[WIDTH, HEIGHT];
        public static Func<int, int, bool> InBoundary => (x, y) => x == 0 || x == WIDTH - 1 || y == 0 || y == HEIGHT - 1;

        static void Main1(string[] args)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for(var j = 0; j < HEIGHT; j++)
                {
                    _gameBoard[i, j] = InBoundary(i,j) ? '=' : ' ';
                }
            }

            Random random = new Random();
            int bombCount = 5;
            HashSet<(int, int)> bombed = new HashSet<(int, int)>();

            while (bombCount > 0) {
                int valueX = random.Next(1, WIDTH);
                int valueY = random.Next(1, HEIGHT);

                if (!InBoundary(valueX, valueY) && !bombed.Contains((valueX, valueY)))
                {
                    _gameBoard[valueX, valueY] = '*';
                    bombed.Add((valueX, valueY));
                    bombCount--;
                }
            }

            for (int i = 1; i < WIDTH - 1; i++)
            {
                for (var j = 1; j < HEIGHT - 1; j++)
                {
                    if (_gameBoard[i, j] == '*')
                    {
                        continue;
                    }
                    int bombCountAround = 0;
                    for (int innerI = i - 1; innerI <= i + 1; innerI++)
                    {
                        for (int innerJ = j - 1; innerJ <= j + 1; innerJ++)
                        {
                            if (_gameBoard[innerI, innerJ] == '*')
                            {
                                bombCountAround++;
                            }
                        }
                    }
                    _gameBoard[i, j] = bombCountAround > 0 ? bombCountAround.ToString()[0] : ' ';
                }
            }

            for (int i = 0; i < WIDTH; i++)
            {
                for (var j = 0; j < HEIGHT; j++)
                {
                    Console.Write(_gameBoard[i, j] == '\0' ? '.' : _gameBoard[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ReadKey();
        }

    }
}

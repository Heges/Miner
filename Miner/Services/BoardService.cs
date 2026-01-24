using MinerDomain;

namespace MinerApplication
{
    public class BoardService
    {
        private readonly GameBoard _board;
        private readonly Random _random = new();

        private Cell _previousCell;

        private int cursorX;
        private int cursorY;

        public BoardService(GameBoard board)
        {
            _board = board;
        }

        public void SetMinesToGameBoard(int dx = 0, int dy = 0, int count = 5)
        {
            int placed = 0;

            //_board.Cells[1, 1].IsBomb = true;

            while (placed < count)
            {
                int x = _random.Next(1, _board.Width - 1);
                int y = _random.Next(1, _board.Height - 1);

                var cell = _board.Cells[x, y];
                if (!cell.IsBomb && x != dx && y != dy)
                {
                    cell.IsBomb = true;
                    placed++;
                }
            }
        }

        public void CountMinesAround(int bombCount = 5)
        {
            for (int i = 1; i < _board.Width - 1; i++)
            {
                for (var j = 1; j < _board.Height - 1; j++)
                {
                    if (_board.Cells[i, j].IsBomb)
                    {
                        continue;
                    }
                    int bombCountAround = 0;
                    for (int innerI = i - 1; innerI <= i + 1; innerI++)
                    {
                        for (int innerJ = j - 1; innerJ <= j + 1; innerJ++)
                        {
                            if (_board.Cells[innerI, innerJ].IsBomb)
                            {
                                bombCountAround++;
                            }
                        }
                    }
                    _board.Cells[i, j].BombsAround = bombCountAround;
                }
            }
        }

        public bool Move(int x, int y)
        {
            int dx = cursorX + x;
            int dy = cursorY + y;

            if (dx > 0 && dx < _board.Width - 1 && dy > 0 && dy < _board.Height - 1)
            {
                if (_previousCell != null)
                {
                    _previousCell.Cursor = false;
                }

                cursorX = dx;
                cursorY = dy;

                _previousCell = _board.Cells[cursorX, cursorY];
                _previousCell.Cursor = true;

                return true;
            }

            return false;
        }

        private void DeepReveal(int x, int y)
        {
            var revealQueque = new Queue<Cell>();

            int dx = x;
            int dy = y;

            revealQueque.Enqueue(_board.Cells[dx, dy]);

            while (revealQueque.Count > 0)
            {
                var currentCell = revealQueque.Dequeue();

                if (currentCell.IsBomb && currentCell.IsMarked)
                    continue;

                currentCell.IsRevealed = true;

                if (currentCell.BombsAround > 0)
                    continue;

                for (int i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        int currentX = currentCell.PositionX + i;
                        int currentY = currentCell.PositionY + j;

                        if (currentX > 0 && currentX < _board.Width - 1 && currentY > 0 && currentY < _board.Height - 1)
                        {
                            if (currentX == 0 && currentY == 0)
                                continue;
                            if (!_board.Cells[currentX, currentY].IsRevealed && !_board.Cells[currentX, currentY].IsMarked)
                            {
                                revealQueque.Enqueue(_board.Cells[currentX, currentY]);
                            }
                        }
                    }
                }
            }
        }

        public Cell Reveal()
        {
            if (cursorX > 0 && cursorX < _board.Width - 1 && cursorY > 0 && cursorY < _board.Height - 1)
            {
                if (_board.Cells[cursorX, cursorY].IsMarked)
                    return _board.Cells[cursorX, cursorY];

                if (_board.Cells[cursorX, cursorY].IsBomb)
                {
                    _board.Cells[cursorX, cursorY].IsRevealed = true;
                    return _board.Cells[cursorX, cursorY];
                }

                DeepReveal(cursorX, cursorY);
                return _board.Cells[cursorX, cursorY];
            }
            return null;
        }

        public bool Flag()
        {
            if (cursorX > 0 && cursorX < _board.Width - 1 && cursorY > 0 && cursorY < _board.Height - 1)
            {
                if (!_board.Cells[cursorX, cursorY].IsRevealed)
                {
                    _board.Cells[cursorX, cursorY].IsMarked = !_board.Cells[cursorX, cursorY].IsMarked;
                }
            }
            return _board.Cells[cursorX, cursorY].IsMarked;
        }

        public void SetCursor(int x, int y)
        {
            Move(x, y);
        }

        public void Habibi(bool habibi)
        {
            for (int i = 1; i < _board.Width - 1; i++)
            {
                for (var j = 1; j < _board.Height - 1; j++)
                {
                    if (habibi)
                        if (_board.Cells[i, j].IsBomb)
                            _board.Cells[i, j].IsRevealed = true;
                }
            }
        }

        public void ResetByDefault(bool unreveal = true, bool unmark = true, bool uncursor = true, bool diffuseBombs = true)
        {
            for (int i = 1; i < _board.Width - 1; i++)
            {
                for (var j = 1; j < _board.Height - 1; j++)
                {
                    _board.Cells[i, j].IsRevealed = unreveal ? false : _board.Cells[i, j].IsRevealed;
                    _board.Cells[i, j].IsMarked = unmark ? false : _board.Cells[i, j].IsMarked;
                    _board.Cells[i, j].Cursor = uncursor ? false : _board.Cells[i, j].Cursor;
                    _board.Cells[i, j].BombsAround = diffuseBombs ? 0 : _board.Cells[i, j].BombsAround;
                    _board.Cells[i, j].IsBomb = diffuseBombs ? false : _board.Cells[i, j].IsBomb;
                }
            }
        }

        public bool Victory()
        {
            for (int i = 1; i < _board.Width - 1; i++)
            {
                for (var j = 1; j < _board.Height - 1; j++)
                {
                    if(!_board.Cells[i, j].IsRevealed && !_board.Cells[i, j].IsBomb && !_board.Cells[i, j].IsMarked)
                        return false;
                }
            }
            return true;
        }
    }
}

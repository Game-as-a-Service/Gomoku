using Domain.Model;

namespace Domain.Board.Board
{
    public class Base
    {
        public int _winner = 0;
        protected int _lastChessType = 0;
        private int[,] _board = new int[15, 15];
        protected int[,] board
        {
            get => _board;
            set
            {
                if (_winner != 0) return;
                _board = value;
                if (CheckWinner()) _winner = _lastChessType;
            }
        }
        protected int[,] _visited = new int[15, 15];

        private static readonly List<Func<Position, Position>> _directions = new List<Func<Position, Position>>()
        {
            p => new Position(p.row, p.columns + 1),
            p => new Position(p.row + 1, p.columns),
            p => new Position(p.row + 1, p.columns + 1),
            p => new Position(p.row - 1, p.columns + 1)
        };
        protected bool CheckWinner()
        {
            Position maxLength = new Position(board.Length - 1, board.GetLength(1) - 1);
            foreach (var direction in _directions)
            {
                var count = CheckWinInDirection(new Position(), maxLength, direction, 1);
                if (count >= 5)
                {
                    return true;
                }
            }
            return false;
        }
        protected int CheckWinInDirection(Position position, Position maxLength, Func<Position, Position> getNextPosition, int count)
        {
            if (position.row > maxLength.row || position.columns > maxLength.columns || this._visited[position.row, position.columns] == 1) return 0;
            this._visited[position.row, position.columns] = 1;

            if (this.board[position.row, position.columns] == this._lastChessType)
            {
                position = getNextPosition(position);
                count = CheckWinInDirection(position, maxLength, getNextPosition, count + 1);
            }
            return count;
        }
    }
}

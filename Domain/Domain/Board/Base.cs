using Domain.Model;

namespace Domain.Board.Board
{
    public class Base
    {
        public int winner;
        private int _lastChessType;
        private int[,] _board;
        private int[,] _visited;
        private int _count;

        public Base()
        {
            winner = 0;
            _lastChessType = 0;
            _board = new int[15, 15];
            _visited = new int[15, 15];
            _count = 0;
        }
        public int this[int row, int column]
        {
            get => _board[row, column];
            set
            {
                if (this.winner != 0) return;
                this._board[row, column] = value;
                this._lastChessType = this._board[row, column];
                this._count++;
                if (CheckWinner(new Position(row, column))) this.winner = this._lastChessType;
                if (this._count == _board.Length && this.winner == 0) this.winner = 3;
            }
        }
        private static readonly List<List<Func<Position, Position>>> _directions = new List<List<Func<Position, Position>>>()
        {
            new List<Func<Position, Position>> {
                x => new Position(x.row, x.columns + 1),
                x => new Position(x.row, x.columns - 1)
            },
            new List<Func<Position, Position>>
            {
                x => new Position(x.row+1, x.columns),
                x => new Position(x.row-1, x.columns)
            },
            new List<Func<Position, Position>>{
                x => new Position(x.row + 1, x.columns + 1),
                x => new Position(x.row - 1, x.columns - 1),
            },
            new List<Func<Position, Position>>()
            {
                x => new Position(x.row - 1, x.columns + 1),
                x => new Position(x.row + 1, x.columns - 1),
            }
        };
        private bool CheckWinner(Position lastPosition)
        {
            Position maxLength = new Position(_board.GetLength(0) - 1, _board.GetLength(1) - 1);
            this._visited = new int[15, 15];
            foreach (var direction in _directions)
            {
                int count = 1;
                foreach (var position in direction)
                {
                    count = CheckWinInDirection(position(lastPosition), maxLength, position, count);
                }
                if (count == 5) return true;
            }
            return false;
        }
        private int CheckWinInDirection(Position position, Position maxLength, Func<Position, Position> getNextPosition, int count)
        {
            if (position.row < 0 || position.columns < 0 || position.row > maxLength.row || position.columns > maxLength.columns
                || this._visited[position.row, position.columns] == 1 || this._board[position.row, position.columns] != this._lastChessType) return count;

            this._visited[position.row, position.columns] = 1;
            count = CheckWinInDirection(getNextPosition(position), maxLength, getNextPosition, ++count);
            return count;
        }
    }
}

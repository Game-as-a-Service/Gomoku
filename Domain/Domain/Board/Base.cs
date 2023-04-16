using Domain.Enum.Board;
using Domain.Model;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Board.Board
{
    public class Base
    {
        protected int _winner = 0;
        protected int _lastChessType = 0;
        protected int[,] _board = new int[15, 15];
        protected int[,] board
        {
            get { return _board; }
            set
            {
                if (_winner != 0) return;
                _board = value;
                CheckWinner();
            }
        }
        protected int[,] _visited = new int[15, 15];

        protected bool CheckWinner()
        {
            Position maxLength = new Position
            {
                row = board.Length,
                columns = board.GetLength(1)
            };

            return true;
        }
        protected int CheckWinInRow(Position position, Position maxLength, int count)
        {
            if (position.row > maxLength.row || this._visited[position.row, position.columns] == 1) return 0;
            this._visited[position.row, position.columns] = 1;

            if (this.board[position.row, position.columns] == this._lastChessType)
            {
                count++;
                position.row++;
                return CheckWinInRow(position, maxLength, count);
            }
            else
            {
                return count;
            }
        }
        protected int CheckWinInColumn(Position position, Position maxLength, int count)
        {
            if (position.columns > maxLength.columns || this._visited[position.row, position.columns] == 1) return 0;
            this._visited[position.row, position.columns] = 1;

            if (this.board[position.row, position.columns] == this._lastChessType)
            {
                count++;
                position.columns++;
                return CheckWinInColumn(position, maxLength, count);
            }
            else
            {
                return count;
            }
        }
        protected int CheckWinInDiagonal(Position position, Position maxLength, int count)
        {
            if (position.row > maxLength.row || position.columns > maxLength.columns 
                || this._visited[position.row, position.columns] == 1) return 0;
            this._visited[position.row, position.columns] = 1;

            if (this.board[position.row, position.columns] == this._lastChessType)
            {
                count++;
                position.columns++;
                position.row++;
                return CheckWinInDiagonal(position, maxLength, count);
            }
            else
            {
                return count;
            }
        }
    }
}

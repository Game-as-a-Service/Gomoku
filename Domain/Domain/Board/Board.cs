using Domain.Board.Board;
using Domain.Enum.Board;
using Domain.Model;

namespace Domain.Board
{
    public class BoardFactory : Base
    {
        public bool set(Position position, int chessType)
        {
            if (this.board[position.row, position.columns] != 0)
            {
                return false;
            }
            this._lastChessType = chessType;
            this.board[position.row, position.columns] = chessType;
            return true;
        }
        public void rollBack()
        {

        }
        public bool checkForLast()
        {
            return true;
        }
    }
}

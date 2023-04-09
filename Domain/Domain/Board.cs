using Domain.Enum;
using Domain.Model;

namespace Domain
{
    public class Board
    {
        public int[,] _board = new int[15,15];
        public bool set(Position position, int chessType)
        {
            if(this._board[position.row, position.columns] != 0)
            {
                return false;
            }
            this._board[position.row, position.columns] = chessType;
            return true;
        }
        public void rollBack()
        {
            
        }
        public bool checkForWin()
        {
            int rowLength = _board.Length;
            int columnLength = _board.GetLength(1);
            return true;
        }
        public bool checkForLost()
        {
            return true;
        }
    }
}

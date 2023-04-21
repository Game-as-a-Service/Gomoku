using Domain.Board.Board;
using Domain.Model;

namespace Domain.Board
{
    public class BoardFactory : Base
    {
        public bool set(Position position, int chessType)
        {
            if (this[position.row, position.columns] != 0)
            {
                return false;
            }
            this[position.row, position.columns] = chessType;
            return true;
        }
        public int get (Position position)
        {
            return this[position.row, position.columns];
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

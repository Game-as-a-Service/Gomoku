using Domain.Board.Board;
using Domain.Model;

namespace Domain.Board
{
    public class BoardFactory : Base
    {
        public bool Set(Position position, int chessType)
        {
            if (this[position.row, position.columns] != 0)
            {
                return false;
            }
            this[position.row, position.columns] = chessType;
            return true;
        }
        public void RollBack()
        {

        }
        public bool CheckForLast()
        {
            return true;
        }
    }
}

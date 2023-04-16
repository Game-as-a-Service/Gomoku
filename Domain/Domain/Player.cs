using Domain.Board;
using Domain.Model;

namespace Domain
{
    public class Player
    {
        private readonly int chessType;
        public Player(int chessType)
        {
            this.chessType = chessType;
        }
        public void put(BoardFactory board, Position position)
        {
            board.set(position, chessType);
        }
        public void undoMove()
        {

        }
    }
}

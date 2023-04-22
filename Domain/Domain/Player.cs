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
        public void Move(BoardFactory board, Position position)
        {
            board.Set(position, chessType);
        }
        public void UndoMove()
        {
            
        }
    }
}

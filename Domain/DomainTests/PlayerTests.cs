using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Domain.Enum;
using Domain.Board;

namespace Domain.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        private readonly Player blackPlayer;
        private readonly Player whitePlayer;
        public PlayerTests()
        {
            blackPlayer = new Player((int)ChessType.Black);
            whitePlayer = new Player((int)ChessType.White);
        }
        [Description("Given\r\n黑棋已有：E7、F7、G7、H7\r\n白棋已有：E8、F8、G8、H8\r\nWhen\r\n下棋：I7\r\nThen\r\n玩家獲勝")]
        [TestMethod()]
        ///<summary>
        ///Given：
        ///<para>黑棋已有：E7、F7、G7、H7</para>
        ///<para>白棋已有：E8、F8、G8、H8</para>
        ///<para>When：</para>
        ///<para>黑方下棋：I7</para>
        ///<para>Then：</para>
        ///<para>玩家獲勝</para>
        /// </summary>
        public void PlayerWinAfterMoveTest()
        {
            BoardFactory board = new BoardFactory();

            #region 設定已有棋子
            this.blackPlayer.Move(board, new Position((int)Columns.E, 7));
            this.blackPlayer.Move(board, new Position((int)Columns.F, 7));
            this.blackPlayer.Move(board, new Position((int)Columns.G, 7));
            this.blackPlayer.Move(board, new Position((int)Columns.H, 7));
            this.whitePlayer.Move(board, new Position((int)Columns.E, 8));
            this.whitePlayer.Move(board, new Position((int)Columns.F, 8));
            this.whitePlayer.Move(board, new Position((int)Columns.G, 8));
            this.whitePlayer.Move(board, new Position((int)Columns.H, 8));
            #endregion
            Assert.AreEqual((int)ChessType.None, board.winner);

            this.blackPlayer.Move(board, new Position((int)Columns.I, 7));

            Assert.AreEqual((int)ChessType.Black, board.winner);
        }
        [Description("Given\r\n黑棋已有:E7、F7\r\n白棋已有:E8、F8\r\nWhen\r\n下棋：G7\r\nThen\r\n未獲勝")]
        [TestMethod()]
        ///<summary>
        ///Given：
        ///<para>黑棋已有：E7、F7</para>
        ///<para>白棋已有：E8、F8</para>
        ///<para>When：</para>
        ///<para>黑方下棋：G7</para>
        ///<para>Then：</para>
        ///<para>玩家未獲勝</para>
        /// </summary>
        public void PlayerNotWinAfterMoveTest()
        {
            BoardFactory board = new BoardFactory();
            #region 設定已有棋子
            this.blackPlayer.Move(board, new Position((int)Columns.E, 7));
            this.blackPlayer.Move(board, new Position((int)Columns.F, 7));
            this.whitePlayer.Move(board, new Position((int)Columns.E, 8));
            this.whitePlayer.Move(board, new Position((int)Columns.F, 8));
            #endregion
            Assert.AreEqual((int)ChessType.None, board.winner);

            this.blackPlayer.Move(board, new Position((int)Columns.G, 7));

            Assert.AreEqual((int)ChessType.None, board.winner);
        }
        [Description("Given\r\n黑棋已有:E7、F7\r\n白棋已有:E8、F8\r\nWhen\r\n下棋：G7\r\nThen\r\n未獲勝")]
        [TestMethod()]
        public void EndedInATieAfterMoveTest()
        {
            BoardFactory board = new BoardFactory();
            #region 設定已有棋子
            for (var row = 0; row < 15; ++row)
            {
                for (var col = 0; col < 15; ++col)
                {
                    if ((row / 4 + col) % 2 == 0) blackPlayer.Move(board, new Position(row, col));
                    else whitePlayer.Move(board, new Position(row, col));
                }
            }
            Assert.AreEqual(3, board.winner);
            #endregion
        }
    }
}
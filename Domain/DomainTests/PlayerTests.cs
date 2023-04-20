using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Domain.Enum;
using Domain.Board;
using System.Diagnostics;
using Domain.Board.Board;

namespace Domain.Tests
{
    [TestClass()]
    public class PlayerTests: Base
    {
        [Description("Given\r\n已有棋子：E7、F7、G7、H7\r\nWhen\r\n下棋：I7\r\nThen\r\n玩家獲勝")]
        [TestMethod()]
        ///<summary>
        ///Given：
        ///<para>黑棋已有：E7、F7、G7、H7</para>
        ///<para>白棋已有：E8、F8、G8、H87</para>
        ///<para>When：</para>
        ///<para>黑方下棋：I7</para>
        ///<para>Then：</para>
        ///<para>玩家獲勝</para>
        /// </summary>
        public void AfterPutPlayerWinTest()
        {
            BoardFactory board = new BoardFactory();
            Player blackPlayer = new Player((int)ChessType.Black);
            Player whitePlayer = new Player((int)ChessType.White);
            #region 設定已有棋子
            blackPlayer.put(board, new Position((int)Columns.E, 7));
            blackPlayer.put(board, new Position((int)Columns.F, 7));
            blackPlayer.put(board, new Position((int)Columns.G, 7));
            blackPlayer.put(board, new Position((int)Columns.H, 7));
            whitePlayer.put(board, new Position((int)Columns.E, 8));
            whitePlayer.put(board, new Position((int)Columns.F, 8));
            whitePlayer.put(board, new Position((int)Columns.G, 8));
            whitePlayer.put(board, new Position((int)Columns.H, 8));
            #endregion

            blackPlayer.put(board, new Position((int)Columns.I, 7));
            
            Assert.AreEqual((int)ChessType.Black, board._winner);
        }
        [TestMethod()]
        public void test()
        {
            this[0, 0] = 1;
        }
    }
}
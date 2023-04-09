using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Enum;

namespace Domain.Tests
{
    [TestClass()]
    public class PlayerTests
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
            Board board = new Board();
            #region 設定已有棋子
            board._board[(int)Columns.E, 7] = (int)ChessType.Black;
            board._board[(int)Columns.F, 7] = (int)ChessType.Black;
            board._board[(int)Columns.G, 7] = (int)ChessType.Black;
            board._board[(int)Columns.H, 7] = (int)ChessType.Black;
            board._board[(int)Columns.E, 8] = (int)ChessType.White;
            board._board[(int)Columns.F, 8] = (int)ChessType.White;
            board._board[(int)Columns.G, 8] = (int)ChessType.White;
            board._board[(int)Columns.H, 8] = (int)ChessType.White;
            #endregion
            Player player = new Player((int)ChessType.Black);
            player.put(board, new Position
            {
                columns = (int)Columns.I,
                row = 7,
            });
            Assert.Fail();
        }
    }
}
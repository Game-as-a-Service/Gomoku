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
        ///<para>已有棋子：E7、F7、G7、H7</para>
        ///<para>When：</para>
        ///<para>下棋：I7</para>
        ///<para>Then：</para>
        ///<para>玩家獲勝</para>
        /// </summary>
        public void putTest()
        {
            Board board = new Board();
            board._board[(int)Columns.E, 7] = 2;
            board._board[(int)Columns.F, 7] = 2;
            board._board[(int)Columns.G, 7] = 2;
            board._board[(int)Columns.H, 7] = 2;

            Player player = new Player();
            var t = Columns.I;
            player.put(new Position
            {
                columns = (int)Columns.I,
                row = 7,
            });
            Assert.Fail();
        }
    }
}
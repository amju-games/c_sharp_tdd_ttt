// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using TicTacToe;

namespace tests
{
    [TestFixture]
    public class PlayerTest
    {
        public PlayerTest ()
        {
        }

        [Test]
        public void OtherPlayerTest()
        {
            Player p1 = Player.X;
            Assert.AreEqual (Player.O, PlayerUtils.OtherPlayer (p1));

            Player p2 = Player.O;
            Assert.AreEqual (Player.X, PlayerUtils.OtherPlayer (p2));
        }
    }
}


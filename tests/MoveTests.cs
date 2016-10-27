// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using TicTacToe;

namespace tests
{
    [TestFixture]
    public class MoveTests
    {
        public MoveTests ()
        {
        }

        [Test]
        public void CreateMoveTest()
        {
            Move m = new Move(1, 2);
            Board b = new Board();
            Assert.IsTrue(b.IsLegal(m));
        }
    }
}


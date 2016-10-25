// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using TicTacToe;

namespace tests
{
    [TestFixture]
    public class AiTests
    {
        public AiTests ()
        {
        }

        [Test]
        public void OpeningMoveTest()
        {
            Ai ai = new Ai ();
            Board b = new Board ();
            int n = Board.GetSize();
            Assert.AreEqual(n * n, b.GetNumEmptySquares());

            ai.MakeMove (b, Player.X);
            Assert.AreEqual(n * n - 1, b.GetNumEmptySquares());
        }

        [Test]
        public void BlockTest()
        {
            Ai ai = new Ai ();
            Board b = new Board ();

        }
    }
}

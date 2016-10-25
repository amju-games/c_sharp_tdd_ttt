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
        public void BadAiOpeningMoveTest()
        {
            Ai ai = new BadAi ();
            Board b = new Board ();
            int n = Board.GetSize();
            Assert.AreEqual(n * n, b.GetNumEmptySquares());

            ai.MakeMove (b, Player.X);
            Assert.AreEqual(n * n - 1, b.GetNumEmptySquares());
        }

        private static void ThrowsBecauseNoMove()
        {
            Ai ai = new BadAi ();
            Board b = new Board ();
            int n = Board.GetSize();
            int nsq = n * n;
            for (int i = 0; i < nsq; i++)
            {
                ai.MakeMove (b, Player.X);
            }
            // Board is full - now try to make a move, will throw
            ai.MakeMove (b, Player.X);
        }

        [Test]
        public void BadAiThrowIfNoMoveTest()
        {
            // Test that Ai::MakeMove throws if there is no available square.
            Assert.Throws(typeof(ApplicationException),
                          new TestDelegate(ThrowsBecauseNoMove));           
        }

        [Test]
        public void BadAiBlockTest()
        {
            // Test the AI blocks a square which would give the opponent a winning line...?
        }
    }
}

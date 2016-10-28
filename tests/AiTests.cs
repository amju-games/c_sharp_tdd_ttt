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

            int numSquares = n * n;
            // Number of legal moves should be the number of squares on the empty board
            Assert.AreEqual(numSquares, b.GetMoves(Player.X).Count);
            Assert.AreEqual(numSquares, b.GetMoves(Player.O).Count);

            ai.MakeMove(b, Player.X);

            // One less square is now available
            Assert.AreEqual(numSquares - 1, b.GetMoves(Player.X).Count);
            Assert.AreEqual(numSquares - 1, b.GetMoves(Player.O).Count);
        }

        private static void ThrowsBecauseNoMove()
        {
            Ai ai = new BadAi ();
            Board b = new Board ();
            int n = Board.GetSize();
            int nsq = n * n;
            for (int i = 0; i < nsq; i++)
            {
                ai.MakeMove(b, Player.X);
            }
            // Board is full - now try to make a move, will throw
            ai.MakeMove(b, Player.X);
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

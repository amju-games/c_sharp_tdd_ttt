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
            ai.MakeMove (b, Player.X);
        }

        [Test]
        public void BlockTest()
        {
            Ai ai = new Ai ();
            Board b = new Board ();

        }
    }
}

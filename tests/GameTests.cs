// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using TicTacToe;

namespace tests
{
    [TestFixture]
    public class GameTests
    {
        public GameTests ()
        {
        }

        [Test]
        public void RunTest()
        {
            Game g = new Game ();
            g.Run ();
        }
    }
}


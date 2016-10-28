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
            // Create AI player, play until board is full or there is a winner
            Board b = new Board();
            Ai ai = new BadAi();
            Player p = Player.X; // starting player

            while (b.GetMoves(p).Count > 0 && b.CalcScore(Player.X) == 0)
            {
                Console.WriteLine("");

                ai.MakeMove(b, p);
                b.Draw ();
                p = PlayerUtils.OtherPlayer(p);
            }
            int score = b.CalcScore(Player.X);
            if (score == 1)
            {
                Console.WriteLine("Win for X!");
            }
            else if (score == -1)
            {
                Console.WriteLine("Win for O!");
            }
            else 
            {
                Console.WriteLine("It's a draw.");
            }
        }
    }
}


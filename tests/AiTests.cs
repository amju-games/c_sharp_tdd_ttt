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
        public void BadAiAgainstBadAiTest()
        {
            // Test 2 bad AIs against eachother.
            const float NUM_GAMES = 100;
            float total = 0;
            for (int i = 0; i < NUM_GAMES; i++)
            {   
                Console.WriteLine("Game {0}...", i);

                int score = RunTest(new BadAi(), new BadAi());
                total += score;
            }
            float mean = total / NUM_GAMES;
            Console.WriteLine("Mean score: {0}.", mean);           

            // You would expect the two bad AIs to draw roughly (score 0).
            // But they are random, and maybe playing first gives an advantage?
            Assert.IsTrue(-0.5 < mean && mean < 0.5);
        }

        // Play a game between the two given AIs. Returns 1 if a win for ai1, -1 if a win
        //  for ai2, 0 if a draw.
        private int RunTest(Ai aiX, Ai aiO)
        {
            // Create AI player, play until board is full or there is a winner
            Board b = new Board();

            while (true)
            {
                if (b.GetMoves(Player.X).Count == 0 || b.CalcScore(Player.X) != 0)
                {
                    break;
                }
                           
                aiX.MakeMove(b, Player.X);
                //b.Draw ();

                if (b.GetMoves(Player.O).Count == 0 || b.CalcScore(Player.X) != 0)
                {
                    break;
                }
                
                aiO.MakeMove(b, Player.O);
                //b.Draw ();
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
            return score;
        }
    }
}

// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TicTacToe;

namespace tests
{
    [TestFixture]
    public class BoardTests
    {
        public BoardTests()
        {
        }

        // Helpers: functions which throw due to bad args
        private static void ThrowingBoardFunc1()
        {
            Board b = new Board();
            b.GetContentsAtSquare(-1, 0);
        }

        private static void ThrowingBoardFunc2()
        {
            Board b = new Board();
            int n = Board.GetSize();
            b.GetContentsAtSquare(n, 0);
        }

        private static void ThrowingBoardFunc3()
        {
            Board b = new Board();
            b.GetContentsAtSquare(0, -1);
        }
        
        private static void ThrowingBoardFunc4()
        {
            Board b = new Board();
            int n = Board.GetSize();
            b.GetContentsAtSquare(0, n);
        }

        [Test]
        public void ThrowOnBadCoordTest()
        {
            Assert.Throws(typeof(ArgumentException),
                          new TestDelegate(ThrowingBoardFunc1));           

            Assert.Throws(typeof(ArgumentException),
                          new TestDelegate(ThrowingBoardFunc2));           

            Assert.Throws(typeof(ArgumentException),
                          new TestDelegate(ThrowingBoardFunc3));           

            Assert.Throws(typeof(ArgumentException),
                          new TestDelegate(ThrowingBoardFunc4));           
        }

        [Test]
        public void InitialStateTest()
        {
            Board b = new Board();
            int n = Board.GetSize();
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++) 
                {
                    SquareContents s = b.GetContentsAtSquare(i, j);
                    Assert.AreEqual(SquareContents.EMPTY, s); // expected, actual
                }
            }
        }

        [Test]
        public void InitialScoreTest()
        {
            Board b = new Board ();

            // Neither player has a winning line, so both players have a score of 0.
            int score = b.CalcScore (Player.O); 
            Assert.AreEqual (0, score);

            score = b.CalcScore (Player.X); 
            Assert.AreEqual (0, score);
        }

        [Test]
        public void ScoreRowTest()
        {
            int n = Board.GetSize ();
            for (int i = 0; i < n; i++) 
            {
                Board b = new Board();

                // Make a winning row
                for (int j = 0; j < n; j++)
                {
                    b.MakeMove(new Move(j, i, Player.X));
                }

                // Board has winning row for X, so score for X is 1
                int score = b.CalcScore (Player.X); 
                Assert.AreEqual (1, score);

                // Board has winning row for X, so score for O is -1
                score = b.CalcScore (Player.O); 
                Assert.AreEqual (-1, score);
            }

            for (int i = 0; i < n; i++) {
                Board b = new Board ();

                for (int j = 0; j < n; j++)
                {
                    b.MakeMove(new Move(j, i, Player.O));
                }

                int score = b.CalcScore (Player.O); 
                Assert.AreEqual (1, score);
                
                score = b.CalcScore (Player.X); 
                Assert.AreEqual (-1, score);
            }
        }

        [Test]
        public void ScoreColumnTest()
        {
            int n = Board.GetSize ();
            for (int i = 0; i < n; i++) {
                Board b = new Board ();

                // Make a winning column
                for (int j = 0; j < n; j++)
                {
                    b.MakeMove(new Move(i, j, Player.X));
                }                

                int score = b.CalcScore (Player.X); 
                Assert.AreEqual (1, score);
                
                score = b.CalcScore (Player.O); 
                Assert.AreEqual (-1, score);
            }
            
            for (int i = 0; i < n; i++) {
                Board b = new Board ();

                // Make a winning column
                for (int j = 0; j < n; j++)
                {
                    b.MakeMove(new Move(i, j, Player.O));
                }

                int score = b.CalcScore (Player.O); 
                Assert.AreEqual (1, score);
                
                score = b.CalcScore (Player.X); 
                Assert.AreEqual (-1, score);
            }
        }

        [Test]
        public void ScoreDiag1Test()
        {
            int n = Board.GetSize ();

            Board b = new Board ();
            // Make diag winning position
            for (int i = 0; i < n; i++) {
                b.MakeMove(new Move(i, i, Player.X));
            }
            int score = b.CalcScore (Player.X); 
            Assert.AreEqual (1, score);
            
            score = b.CalcScore (Player.O); 
            Assert.AreEqual (-1, score);
        }

        [Test]
        public void ScoreDiag2Test()
        {
            int n = Board.GetSize ();
            
            Board b = new Board ();
            // Make diag winning position
            for (int i = 0; i < n; i++) {
                b.MakeMove(new Move(i, i, Player.O));
            }
            int score = b.CalcScore (Player.X); 
            Assert.AreEqual (-1, score);
            
            score = b.CalcScore (Player.O); 
            Assert.AreEqual (1, score);
        }

        [Test]
        public void ScoreDiag3Test()
        {
            int n = Board.GetSize ();
            
            Board b = new Board ();
            // Make diag winning position
            for (int i = 0; i < n; i++) {
                b.MakeMove(new Move(i, n - i - 1, Player.X));
            }
            int score = b.CalcScore (Player.X); 
            Assert.AreEqual (1, score);
            
            score = b.CalcScore (Player.O); 
            Assert.AreEqual (-1, score);
        }
        
        [Test]
        public void ScoreDiag4Test()
        {
            int n = Board.GetSize ();
            
            Board b = new Board ();
            // Make diag winning position
            for (int i = 0; i < n; i++) {
                b.MakeMove(new Move(i, n - i - 1, Player.O));
            }
            int score = b.CalcScore (Player.X); 
            Assert.AreEqual (-1, score);
            
            score = b.CalcScore (Player.O); 
            Assert.AreEqual (1, score);
        }

        [Test]
        public void MakeMoveTest()
        {
            // Test that after making a move, the square contains the expected contents.
            Board b = new Board ();
            int n = Board.GetSize ();
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++) 
                {
                    b.MakeMove(new Move(i, j, Player.X)); 
                    SquareContents s = b.GetContentsAtSquare (i, j);
                    Assert.AreEqual (SquareContents.X, s);  // expected, actual

                    b.MakeMove(new Move(i, j, Player.O)); 
                    s = b.GetContentsAtSquare (i, j);
                    Assert.AreEqual (SquareContents.O, s);  // expected, actual
                }
            }
        }

        [Test]
        public void IsMoveLegalTest()
        {
            Board b = new Board ();
            int n = Board.GetSize ();
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++) 
                {
                    // Square should be empty, so a legal move for either player
                    Assert.IsTrue(b.IsLegal(new Move(i, j, Player.X)));
                    Assert.IsTrue(b.IsLegal(new Move(i, j, Player.O)));

                    b.MakeMove(new Move(i, j, Player.X)); 

                    // Now square is non-empty, not a legal move for either player
                    Assert.IsFalse(b.IsLegal(new Move(i, j, Player.X)));
                    Assert.IsFalse(b.IsLegal(new Move(i, j, Player.O)));
                }
            }
        }

        [Test]
        public void MoveListTest()
        {
            // Tests on the list of valid moves for a given Board
            Board b = new Board();
            int n = Board.GetSize();

            // Empty board, both players should have n * n possible moves
            List<Move> movesX = b.GetMoves(Player.X);
            Assert.AreEqual(n * n, movesX.Count);

            List<Move> movesO = b.GetMoves(Player.X);
            Assert.AreEqual(n * n, movesO.Count);
        }
    }
}


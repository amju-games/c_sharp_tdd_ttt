// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------

using NUnit.Framework;
using System;
using TicTacToe;

namespace tests
{
	[TestFixture]
	public class BoardTests
	{
		public BoardTests()
		{
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
			Board b = new Board();

			int score = b.CalcScore(Player.O); 
			Assert.AreEqual(0, score);

			score = b.CalcScore(Player.X); 
			Assert.AreEqual(0, score);
		}

		[Test]
		public void ScoreRowTest()
		{
			int n = Board.GetSize();
			for (int i = 0; i < n; i++)
			{
				Board b = new Board();

				b.MakeMove(0, i, SquareContents.X);
				b.MakeMove(1, i, SquareContents.X);
				b.MakeMove(2, i, SquareContents.X);

				int score = b.CalcScore(Player.X); 
				Assert.AreEqual(1, score);

				score = b.CalcScore(Player.O); 
				Assert.AreEqual(-1, score);
			}

			for (int i = 0; i < n; i++)
			{
				Board b = new Board();

				b.MakeMove(0, i, SquareContents.O);
				b.MakeMove(1, i, SquareContents.O);
				b.MakeMove(2, i, SquareContents.O);

				int score = b.CalcScore(Player.O); 
				Assert.AreEqual(1, score);
				
				score = b.CalcScore(Player.X); 
				Assert.AreEqual(-1, score);
			}
		}

		[Test]
		public void ScoreColumnTest()
		{
			int n = Board.GetSize();
			for (int i = 0; i < n; i++)
			{
				Board b = new Board();
				
				b.MakeMove(i, 0, SquareContents.X);
				b.MakeMove(i, 1, SquareContents.X);
				b.MakeMove(i, 2, SquareContents.X);
				
				int score = b.CalcScore(Player.X); 
				Assert.AreEqual(1, score);
				
				score = b.CalcScore(Player.O); 
				Assert.AreEqual(-1, score);
			}
			
			for (int i = 0; i < n; i++)
			{
				Board b = new Board();
				
				b.MakeMove(i, 0, SquareContents.O);
				b.MakeMove(i, 1, SquareContents.O);
				b.MakeMove(i, 2, SquareContents.O);
				
				int score = b.CalcScore(Player.O); 
				Assert.AreEqual(1, score);
				
				score = b.CalcScore(Player.X); 
				Assert.AreEqual(-1, score);
			}
		}

		[Test]
		public void ScoreDiag1Test()
		{
			int n = Board.GetSize();

			Board b = new Board();
			// Make diag winning position
			for (int i = 0; i < n; i++)
			{
				b.MakeMove(i, i, SquareContents.X);
			}
			int score = b.CalcScore(Player.X); 
			Assert.AreEqual(1, score);
			
			score = b.CalcScore(Player.O); 
			Assert.AreEqual(-1, score);
		}

		[Test]
		public void ScoreDiag2Test()
		{
			int n = Board.GetSize();
			
			Board b = new Board();
			// Make diag winning position
			for (int i = 0; i < n; i++)
			{
				b.MakeMove(i, i, SquareContents.O);
			}
			int score = b.CalcScore(Player.X); 
			Assert.AreEqual(-1, score);
			
			score = b.CalcScore(Player.O); 
			Assert.AreEqual(1, score);
		}

		[Test]
		public void ScoreDiag3Test()
		{
			int n = Board.GetSize();
			
			Board b = new Board();
			// Make diag winning position
			for (int i = 0; i < n; i++)
			{
				b.MakeMove(i, n - i - 1, SquareContents.X);
			}
			int score = b.CalcScore(Player.X); 
			Assert.AreEqual(1, score);
			
			score = b.CalcScore(Player.O); 
			Assert.AreEqual(-1, score);
		}
		
		[Test]
		public void ScoreDiag4Test()
		{
			int n = Board.GetSize();
			
			Board b = new Board();
			// Make diag winning position
			for (int i = 0; i < n; i++)
			{
				b.MakeMove(i, n - i - 1, SquareContents.O);
			}
			int score = b.CalcScore(Player.X); 
			Assert.AreEqual(-1, score);
			
			score = b.CalcScore(Player.O); 
			Assert.AreEqual(1, score);
		}

		[Test]
		public void MakeMoveTest()
		{
			Board b = new Board();
			int n = Board.GetSize();
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					b.MakeMove(i, j, SquareContents.X); 
		   			SquareContents s = b.GetContentsAtSquare(i, j);
					Assert.AreEqual(SquareContents.X, s);  // expected, actual

					b.MakeMove(i, j, SquareContents.O); 
					s = b.GetContentsAtSquare(i, j);
					Assert.AreEqual(SquareContents.O, s);  // expected, actual
				}
			}
		}

		[Test]
		public void IsMoveLegalTest()
		{
			Board b = new Board();
			int n = Board.GetSize();
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Assert.IsTrue(b.IsLegal(i, j));
					b.MakeMove(i, j, SquareContents.X); 
					Assert.IsFalse(b.IsLegal(i, j));
				}
			}
		}
	}
}


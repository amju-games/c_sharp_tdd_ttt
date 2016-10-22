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
			int n = b.GetSize();
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
		public void ScoreTest()
		{
			Board b = new Board();

			// Try some scenarios
			b.MakeMove(0, 0, SquareContents.X);
			b.MakeMove(1, 0, SquareContents.X);
			b.MakeMove(2, 0, SquareContents.X);

			int score = b.CalcScore(Player.X); 
			Assert.AreEqual(1, score);

			score = b.CalcScore(Player.O); 
			Assert.AreEqual(-1, score);
		}

		[Test]
		public void MakeMoveTest()
		{
			Board b = new Board();
			int n = b.GetSize();
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
			int n = b.GetSize();
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


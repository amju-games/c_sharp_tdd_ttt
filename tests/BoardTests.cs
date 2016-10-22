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
			int score = b.CalcScore(); // TODO calc score for given player - add param
			Assert.AreEqual(0, score);
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
	}
}


// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------

using System;

namespace TicTacToe
{
	public class Board
	{
		private static int BOARD_SIZE = 3;

		public int GetSize()
		{
			return BOARD_SIZE;
		}

		public Board ()
		{
			m_squares = new SquareContents[BOARD_SIZE, BOARD_SIZE];
			for (int i = 0; i < BOARD_SIZE; i++) 
			{
				for (int j = 0; j < BOARD_SIZE; j++)
				{
				    m_squares[i,j] = SquareContents.EMPTY;
				}
			}
		}

		public SquareContents GetContentsAtSquare(int i, int j)
		{
			return m_squares[i, j];
		}

		//[Pure] // no side effects, i.e. const - this is not built in, 
		//  it's in another project called Code Contracts
		public int CalcScore(Player p) 
		{
			return 0;
		}

		// Sets square to given value.
		public void MakeMove(int i, int j, SquareContents s)
		{
			m_squares[i, j] = s;
		}

		public bool IsLegal(int i, int j)
		{
			return (m_squares[i, j] == SquareContents.EMPTY);
		}

		private SquareContents[,] m_squares;
	}
}


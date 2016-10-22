// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------

using System;

namespace TicTacToe
{
	public class Board
	{
		private static int BOARD_SIZE = 3;

		public static int GetSize()
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

		// Return 1 if board position is a win for player p. 
		// Return -1 if a lost position for player p.
		// Return 0 if there is no winner.
		//[Pure] 
		public int CalcScore(Player p) 
		{
			if (CalcScoreInternal(p) == 1)
			{
				return 1;
			}

			if (CalcScoreInternal(OtherPlayer(p)) == 1)
			{
				return -1;
			}

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

		// Return 1 if a winning position for player p
		// Else return 0.
		private int CalcScoreInternal(Player p)
		{
			//Console.WriteLine("CalcScoreInternal for player: " + (p == Player.O ? "O" : "X"));

			bool diag1 = true;
			bool diag2 = true;
			for (int i = 0; i < BOARD_SIZE; i++)
			{
				bool column = true;
				bool row = true;
				// Check rows and columns
				for (int j = 0; j < BOARD_SIZE; j++)
				{
					if (!DoesSquareBelongToPlayer(i, j, p))
					{
						column = false;
					}

					if (!DoesSquareBelongToPlayer(j, i, p))
					{
						row = false;
					}
				}

				if (column || row)
				{
					return 1;
				}

				// Check diagonals
				if (!DoesSquareBelongToPlayer(i, i, p))
				{
					diag1 = false;
				}

				if (!DoesSquareBelongToPlayer(i, BOARD_SIZE - i - 1, p))
				{
					diag2 = false;
				}
			}

			if (diag1 || diag2)
			{
				return 1;
			}

			return 0;
		}

		private Player OtherPlayer(Player p)
		{
			return (p == Player.O) ? Player.X : Player.O;
		}

		private bool DoesSquareBelongToPlayer(int i, int j, Player p)
		{
			SquareContents s = m_squares[i, j];
			if (p == Player.O) return (s == SquareContents.O);
			return (s == SquareContents.X);
		}

		private SquareContents[,] m_squares;
	}
}


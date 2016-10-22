// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------

using System;
using TicTacToe;

namespace c_console_test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Game g = new Game ();

			Board b = new Board();
			
			int score = b.CalcScore(Player.O); 


			Console.WriteLine ("Hello World!");
		}
	}
}

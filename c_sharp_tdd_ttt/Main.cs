// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using System;
using TicTacToe;

namespace c_console_test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("Hello, this is an awesome game!");

            Game g = new Game ();
            g.Run ();
        }
    }
}

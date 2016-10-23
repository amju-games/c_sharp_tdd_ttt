// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using System;

namespace TicTacToe
{
    public class Game
    {
        public Game ()
        {
            m_board = new Board ();
            m_gameIsOver = false;
        }

        public void Run()
        {
            int score = m_board.CalcScore (Player.O); 
            m_board.Draw ();
            Console.WriteLine ("Enter a move!");
        }

        private Board m_board;
        private bool m_gameIsOver;
    }
}


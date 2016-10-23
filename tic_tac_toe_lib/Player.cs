// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using System;

namespace TicTacToe
{
    public enum Player
    {
        O,
        X
    }

    public class PlayerUtils
    {
        public static Player OtherPlayer(Player p)
        {
            return (p == Player.O) ? Player.X : Player.O;
        }
    }
}


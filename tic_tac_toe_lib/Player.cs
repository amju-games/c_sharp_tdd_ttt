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

        // Convert player (O or X) to square contents type, which also has
        //  'empty' value.
        public static SquareContents SquareContentsFromPlayer(Player p)
        {
            if (p == Player.O)
            {
                return SquareContents.O;
            }
            return SquareContents.X;
        }
    }
}

